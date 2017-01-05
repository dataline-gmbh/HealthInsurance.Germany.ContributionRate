using System;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1.Loaders
{
    /// <summary>
    /// Event-Argumente für den Fortschritt des Beitragssatzdatei-Downloads
    /// </summary>
    public class FileDownloadProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="position"></param>
        public FileDownloadProgressEventArgs(long position)
        {
            Position = position;
        }

        /// <summary>
        /// Position der heruntergeladenen Datei
        /// </summary>
        public long Position { get; private set; }
    }
}
