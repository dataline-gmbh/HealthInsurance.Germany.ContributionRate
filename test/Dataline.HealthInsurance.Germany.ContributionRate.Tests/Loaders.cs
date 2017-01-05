using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Dataline.HealthInsurance.ContributionRateImport.Tests
{
    static class Loaders
    {
        public static Task<V5_1.Beitragssatzdatei> LoadTestV5_1Async()
        {
            var loader = new V5_1.Loaders.ZipArchiveLoader(new V5_1.BeitragssatzdateiDeserializer());
            using (var fileStream = new FileStream(@"Daten\EBSD0-GES_V51_2016_0211.zip", FileMode.Open, FileAccess.Read))
            {
                return loader.LoadAsync(fileStream, CancellationToken.None);
            }
        }
    }
}
