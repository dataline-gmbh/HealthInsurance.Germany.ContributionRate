using System;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1.Loaders
{
    /// <summary>
    /// Event-Argumente für den Start des Downloads einer Beitragssatzdatei
    /// </summary>
    public class FileDownloadStartingEventArgs : EventArgs
    {
        private readonly BeitragssatzdateiInfo _info;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="info"></param>
        public FileDownloadStartingEventArgs(BeitragssatzdateiInfo info)
        {
            _info = info;
        }

        /// <summary>
        /// Der Dateiname
        /// </summary>
        public string Name => _info.FileName;

        /// <summary>
        /// Die Länge der zu ladenden Datei
        /// </summary>
        public long? Length => _info.Length;
    }
}
