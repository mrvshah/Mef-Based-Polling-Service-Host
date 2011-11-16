using System;
using System.Configuration;
using System.Reflection;

namespace Core
{
	/// <summary>
	/// Base class for all services
	/// </summary>
	public abstract class PollingService : IPollingService
	{
		/// <summary>
		/// Defines the method to be called when the command is invoked
		/// </summary>
		public abstract void Execute();

		/// <summary>
		/// Gets or sets the name of the service
		/// </summary>
		public abstract string Name { get; set; }

		/// <summary>
		/// Gets or sets the poll interval
		/// </summary>
		public TimeSpan PollInterval { get; set; }


		/// <summary>
		/// Initializes a new instance of the <see cref="PollingService"/> class.
		/// </summary>
		protected PollingService()
		{
			var pollingInterval = int.Parse(ConfigurationManager.OpenExeConfiguration(Assembly.GetCallingAssembly().Location).AppSettings.Settings["PollInterval"].Value);
			PollInterval = new TimeSpan(0, 0, 0, pollingInterval);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format(Name);
		}
	}
}