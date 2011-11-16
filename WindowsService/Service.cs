using System.ServiceProcess;
using Engine;
using log4net.Config;

namespace WindowsService
{
	public partial class Service : ServiceBase
	{
		private readonly IPollingServiceRunner pollingServiceRunner;

		public Service()
		{
			XmlConfigurator.Configure();

			InitializeComponent();
			pollingServiceRunner = new PollingServiceRunner();

			CanPauseAndContinue = true;
		}

		protected override void OnStart(string[] args)
		{
			pollingServiceRunner.OnStart();
		}

		protected override void OnStop()
		{
			pollingServiceRunner.OnStop();
		}

		protected override void OnPause()
		{
			pollingServiceRunner.OnPause();
		}

		protected override void OnContinue()
		{
			pollingServiceRunner.OnContinue();
		}
	}
}
