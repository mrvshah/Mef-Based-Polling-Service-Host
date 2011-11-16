using Core;

namespace ProcessInvoiceService
{
	/// <summary>
	/// Defines a service to process invoices
	/// </summary>
	public class ProcessInvoice : PollingService
	{
		/// <summary>
		/// Gets or sets the name of the service
		/// </summary>
		public override sealed string Name { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessInvoice"/> class.
		/// </summary>
		public ProcessInvoice()
		{
			Name = "Invoice processing service";
		}

		/// <summary>
		/// Actual work to be done for invoice service
		/// </summary>
		public override void Execute()
		{

		}
	}
}
