using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Dataline.HealthInsurance.Germany.ContributionRate.Tests
{
    static class Loaders
    {
        public static Task<V5_1.Beitragssatzdatei> LoadTestV5_1Async()
        {
            var asm = typeof(Loaders).GetTypeInfo().Assembly;
            var rootPath = Path.GetDirectoryName(asm.Location);
            var fileName = Path.Combine(rootPath, "Daten", "EBSD0-GES_V51_2016_0211.zip");
            var loader = new V5_1.Loaders.ZipArchiveLoader(new V5_1.BeitragssatzdateiDeserializer());
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return loader.LoadAsync(fileStream, CancellationToken.None);
            }
        }
    }
}
