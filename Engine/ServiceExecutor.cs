using System;
using System.Threading;
using Core;
using log4net;
using Utilities.Log4Net;
using Utilities.Threading;

namespace Engine
{
	/// <summary>
	/// Helper class to run a service
	/// </summary>
	public class ServiceExecutor
	{
		private static readonly ILog log = LogWrapper.Instance.Get<ServiceExecutor>();

		/// <summary>
		/// Executes a service
		/// </summary>
		/// <param name="pollingService">The service to run</param>
		/// <param name="token">Cancellation token</param>
		public static void Execute(IPollingService pollingService, CancellationToken token)
		{
			try
			{
				Thread.CurrentThread.TrySetName(pollingService.Name);

				while (!token.IsCancellationRequested)
				{
					log.Info(string.Format("Executing service {0} at {1}", pollingService.Name, DateTime.UtcNow));
					pollingService.Execute();
					Thread.Sleep(pollingService.PollInterval);
				}

				log.Info(string.Format("Cancellation request found in {0} thread", Thread.CurrentThread.Name));
				token.ThrowIfCancellationRequested();
			}
			catch (Exception ex)
			{
				log.Info("Exception in Service thread");
				log.Error(ex);
			}
		}
	}
}