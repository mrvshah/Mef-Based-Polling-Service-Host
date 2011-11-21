using System;
using Core;
using Engine;
using log4net.Config;

namespace ConsoleHost
{
	class Program
	{
		static void Main()
		{
			//XmlConfigurator.Configure();

			var pollingServiceRunner = new PollingServiceRunner(StartupValidationProvider.GetAllValidators());
			pollingServiceRunner.OnStart();
			Console.WriteLine("Service started");
			Console.WriteLine("Press enter to stop the service");
			Console.ReadLine();
			pollingServiceRunner.OnStop();
		}
	}
}
