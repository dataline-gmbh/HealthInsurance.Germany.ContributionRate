using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1
{
    public interface ILocalLoader
    {
        /// <summary>
        /// Laden der Beitragssatzdatei
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Beitragssatzdatei> LoadAsync(Stream stream, CancellationToken ct);
    }
}
