using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using Core;
using log4net;
using Utilities.Configuration;

namespace Engine
{
	/// <summary>
	/// Class to provide list of <see cref="IPollingService"/>
	/// </summary>
	public class MefServicesProvider
	{
		private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		[ImportMany(typeof(IPollingService))]
		private IEnumerable<IPollingService> Services { get; set; }

		/// <summary>
		/// Loops through each subdirecotry in LiveServicesDirectory defined in appSettings to import services to run
		/// </summary>
		/// <returns>List of <see cref="IPollingService"/></returns>
		public IEnumerable<IPollingService> GetServices()
		{
			var liveServicesDirectory = AppSettingsReader.Get<string>("LiveServicesDirectory");
			log.Info(string.Format("Lookin into directory {0} for services to run", liveServicesDirectory));

			var directoryCatalogues = Directory.GetDirectories(liveServicesDirectory).Select(directory => new DirectoryCatalog(directory));

			var aggregateCatalog = new AggregateCatalog(directoryCatalogues);
			var container = new CompositionContainer(aggregateCatalog);
			var batch = new CompositionBatch();
			batch.AddPart(this);
			container.Compose(batch);

			return Services;
		}
	}
}