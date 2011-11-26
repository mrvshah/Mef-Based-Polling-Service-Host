using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core;
using log4net;
using Utilities.AppStartupValidation;
using Utilities.Configuration;
using Utilities.Log4Net;
using Utilities.Mef;
using Utilities.Threading;

namespace Engine
{
	/// <summary>
	/// Polling service runner
	/// </summary>
	public class PollingServiceRunner : IPollingServiceRunner
	{
		private static readonly ILog log = LogWrapper.Instance.Get<PollingServiceRunner>();

		private readonly IList<string> currentlyRunningServices = new List<string>();
		private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

		/// <summary>
		/// Initializes a new instance of the <see cref="PollingServiceRunner"/> class
		/// </summary>
		public PollingServiceRunner()
			: this(null)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PollingServiceRunner"/> class
		/// </summary>
		/// <param name="validators">The validators.</param>
		public PollingServiceRunner(IEnumerable<IValidator> validators)
		{
			if (validators != null)
			{
				AppStartupValidationExecutor.ValidateAll(validators);
			}
		}

		/// <summary>
		/// Executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
		/// </summary>
		public void OnStart()
		{
			Thread.CurrentThread.TrySetName("Main");

			log.Info("Starting service");

			var token = cancellationTokenSource.Token;

			Task.Factory.StartNew(() => LookUpServicesAndStart(token), token);

			log.Info("Service started");
		}

		/// <summary>
		/// Executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
		/// </summary>
		public void OnStop()
		{
			log.Info("Stopping service");
			log.Info("Service stopped");
		}

		/// <summary>
		/// Executes when a Pause command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service pauses.
		/// </summary>
		public void OnPause()
		{
			log.Info("Pausing service");
			cancellationTokenSource.Cancel();
			log.Info("Service paused");
		}

		/// <summary>
		/// Executes when a Continue command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service resumes normal functioning after being paused.
		/// </summary>
		public void OnContinue()
		{
			log.Info("Continuing service");
			cancellationTokenSource = new CancellationTokenSource(); // reset cancellation token so that new threads can be started
			currentlyRunningServices.Clear(); // repopulate list of services as this is a fresh start
			OnStart();
			log.Info("Service continued");
		}

		/// <summary>
		/// Find services to run and start them
		/// </summary>
		/// <param name="token">Cancellation token</param>
		private void LookUpServicesAndStart(CancellationToken token)
		{
			try
			{
				Thread.CurrentThread.TrySetName("Worker");

				log.Info("Starting Worker thread");

				while (!token.IsCancellationRequested)
				{
					log.Info("Looking into directory for live services");

					var services = new ImportManyFromDirectory<IPollingService>().Get(AppSettingsReader.Get<string>(AppSettingsKeys.LIVE_SERVICES_DIRECTORY));

					// only run if new service is found
					var newServices = services.Where(s => !currentlyRunningServices.Contains(s.Name));

					if (services.Count() > 0 && newServices.Count() > 0)
					{
						foreach (var service in newServices)
						{
							IPollingService pollingService = service;

							log.Info(string.Format("Starting service - {0}", pollingService));

							Task.Factory.StartNew(() => ServiceExecutor.Execute(pollingService, token), token);

							currentlyRunningServices.Add(pollingService.Name);
						}
					}
					else
					{
						log.Info("There is no new service to run");
					}

					Thread.Sleep(new TimeSpan(0, 0, 0, AppSettingsReader.Get<int>(AppSettingsKeys.LOOK_UP_SERVICE_POLL_INTERVAL)));
				}

				log.Info("Cancellation request found in worker thread");
				token.ThrowIfCancellationRequested();
			}
			catch (Exception ex)
			{
				log.Info("Exception in Worker thread");
				log.Error(ex);
			}
		}
	}
}