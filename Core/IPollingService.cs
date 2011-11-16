using System.ComponentModel.Composition;

namespace Core
{
	/// <summary>
	/// Defines a service that can be exported
	/// </summary>
	[InheritedExport]
	public interface IPollingService : IScheduler, ICommand
	{
		/// <summary>
		/// Gets or sets the name of the service
		/// </summary>
		string Name { get; set; }
	}
}