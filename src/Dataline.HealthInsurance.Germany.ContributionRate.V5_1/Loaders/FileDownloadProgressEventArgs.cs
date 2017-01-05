using System;

namespace Dataline.HealthInsurance.Germany.ContributionRate.V5_1.Loaders
{
    /// <summary>
    /// Event-Argumente für den Fortschritt des Beitragssatzdatei-Downloads
    /// </summary>
    public class FileDownloadProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="FileDownloadProgressEventArgs"/> Klasse.
        /// </summary>
        /// <param name="position">Die Länge der bereits geladenen Daten</param>
        public FileDownloadProgressEventArgs(long position)
        {
            Position = position;
        }

        /// <summary>
        /// Holt die Position der heruntergeladenen Datei
        /// </summary>
        public long Position { get; }
    }
}
