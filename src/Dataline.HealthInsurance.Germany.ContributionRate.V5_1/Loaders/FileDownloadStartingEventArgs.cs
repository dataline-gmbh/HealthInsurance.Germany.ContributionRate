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
        /// Initialisiert eine neue Instanz der <see cref="FileDownloadStartingEventArgs"/> Klasse.
        /// </summary>
        /// <param name="info">Die internen Beitragssatzdatei-Informationen</param>
        public FileDownloadStartingEventArgs(BeitragssatzdateiInfo info)
        {
            _info = info;
        }

        /// <summary>
        /// Holt den Dateinamen der Beitragssatzdatei
        /// </summary>
        public string Name => _info.FileName;

        /// <summary>
        /// Holt die Länge der zu ladenden Datei
        /// </summary>
        public long? Length => _info.Length;
    }
}
