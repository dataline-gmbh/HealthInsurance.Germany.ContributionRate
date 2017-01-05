using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Dataline.HealthInsurance.Germany.ContributionRate.V5_1
{
    /// <summary>
    /// Schnittstelle für das Laden von Beitragssatzdateien aus einem Datenstrom
    /// </summary>
    public interface IStreamingLoader
    {
        /// <summary>
        /// Laden der Beitragssatzdatei
        /// </summary>
        /// <param name="stream">Der Datenstrom aus dem die Beitragssatzdatei geladen werden soll</param>
        /// <param name="ct">Das <see cref="CancellationToken"/> über das ein Abbruch des Ladens möglich ist</param>
        /// <returns>Die deserialisierte Beitragssatzdatei</returns>
        Task<Beitragssatzdatei> LoadAsync(Stream stream, CancellationToken ct);
    }
}
