using Core;

namespace ProcessOrderService
{
	/// <summary>
	/// Defines a service to process orders
	/// </summary>
	public class ProcessOrder : PollingService
	{
		/// <summary>
		/// Gets or sets the name of the service
		/// </summary>
		public override sealed string Name { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessOrder"/> class.
		/// </summary>
		public ProcessOrder()
		{
			Name = "Order processing service";
		}

		/// <summary>
		/// Actual work to be done for invoice service
		/// </summary>
		public override void Execute()
		{

		}
	}
}
