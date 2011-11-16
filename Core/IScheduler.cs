using System;

namespace Core
{
	/// <summary>
	/// Defines a scheduler for a service
	/// </summary>
	public interface IScheduler
	{
		/// <summary>
		/// Gets or sets the poll interval
		/// </summary>
		TimeSpan PollInterval { get; set; }
	}
}