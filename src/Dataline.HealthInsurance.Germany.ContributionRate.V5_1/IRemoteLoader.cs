using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dataline.HealthInsurance.Germany.ContributionRate.V5_1
{
    /// <summary>
    /// Schnittstelle für ein Lade-Modul für die Beitragssatzdatei
    /// </summary>
    public interface IRemoteLoader
    {
        /// <summary>
        /// Laden der Beitragssatzdatei-Information
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<BeitragssatzdateiInfo> LoadInfoAsync(CancellationToken ct);

        /// <summary>
        /// Laden der Beitragssatzdatei
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Beitragssatzdatei> LoadAsync(CancellationToken ct);
    }
}
