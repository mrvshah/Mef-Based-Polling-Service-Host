using System;
using System.Reflection;
using System.Threading;
using Core;
using log4net;
using Utilities.Threading;

namespace Engine
{
	/// <summary>
	/// Helper class to run a service
	/// </summary>
	public class ServiceExecutor
	{
		private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
					Log.Info(string.Format("Executing service {0} at {1}", pollingService.Name, DateTime.UtcNow));
					pollingService.Execute();
					Thread.Sleep(pollingService.PollInterval);
				}

				Log.Info(string.Format("Cancellation request found in {0} thread", Thread.CurrentThread.Name));
				token.ThrowIfCancellationRequested();
			}
			catch (Exception ex)
			{
				Log.Info("Exception in Service thread");
				Log.Error(ex);
			}
		}
	}
}