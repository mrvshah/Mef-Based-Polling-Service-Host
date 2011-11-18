using System.Collections.Generic;
using Utilities.AppStartupValidation;

namespace Core
{
	public class StartupValidationProvider
	{
		public static IEnumerable<IValidator> GetAllValidators()
		{
			IList<IValidator> validators = new List<IValidator>();

			var appSettingsValidator =
				new AppSettingsValidator(new[]
				                         	{
				                         		AppSettingsKeys.LIVE_SERVICES_DIRECTORY, 
														AppSettingsKeys.LOOK_UP_SERVICE_POLL_INTERVAL
				                         	});

			validators.Add(appSettingsValidator);

			return validators;
		}
	}
}