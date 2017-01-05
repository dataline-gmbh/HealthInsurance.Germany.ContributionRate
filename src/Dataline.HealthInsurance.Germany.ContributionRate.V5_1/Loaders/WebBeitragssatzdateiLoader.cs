using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1.Loaders
{
    /// <summary>
    /// Basis-Klasse für Lade-Module, die die Beitragssatzdatei aus dem Internet laden
    /// </summary>
    public abstract class WebBeitragssatzdateiLoader : IRemoteLoader
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="deserializer"></param>
        /// <param name="proxy"></param>
        protected WebBeitragssatzdateiLoader(IDeserializer deserializer, IWebProxy proxy)
        {
            Proxy = proxy;
            Deserializer = deserializer;
        }

        /// <summary>
        /// Wird ausgelöst, wenn der Download der Dateien beginnt
        /// </summary>
        public event EventHandler DownloadStarting;

        /// <summary>
        /// Wird ausgelöst, wenn der Download der Dateien beendet ist
        /// </summary>
        public event EventHandler DownloadFinished;

        /// <summary>
        /// Wird ausgelöst, wenn der Datei-Download beginnt
        /// </summary>
        public event EventHandler<FileDownloadStartingEventArgs> FileDownloadStarting;

        /// <summary>
        /// Wird ausgelöst, während eine einzelne Datei heruntergeladen wird
        /// </summary>
        public event EventHandler<FileDownloadProgressEventArgs> FileDownloadProgress;

        /// <summary>
        /// Wird ausgelöst, wenn der Datei-Download endet
        /// </summary>
        public event EventHandler FileDownloadFinished;

        /// <summary>
        /// Proxy-Server
        /// </summary>
        public IWebProxy Proxy { get; }

        /// <summary>
        /// Holt den Deserializer
        /// </summary>
        protected IDeserializer Deserializer { get; }

        /// <summary>
        /// Event für den Beginn der Downloads auslösen
        /// </summary>
        protected virtual void OnDownloadStarting()
        {
            DownloadStarting?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Event für das Ende der Downloads auslösen
        /// </summary>
        protected virtual void OnDownloadFinished()
        {
            DownloadFinished?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Event für den Start des Datei-Downloads auslösen
        /// </summary>
        protected virtual void OnFileDownloadStarting(BeitragssatzdateiInfo info)
        {
            FileDownloadStarting?.Invoke(this, new FileDownloadStartingEventArgs(info));
        }

        /// <summary>
        /// Event für das Fortschritt des Datei-Downloads auslösen
        /// </summary>
        /// <param name="position"></param>
        protected virtual void OnFileDownloadProgress(long position)
        {
            FileDownloadProgress?.Invoke(this, new FileDownloadProgressEventArgs(position));
        }

        /// <summary>
        /// Event für das Ende des Datei-Downloads auslösen
        /// </summary>
        protected virtual void OnFileDownloadFinished()
        {
            FileDownloadFinished?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Laden der Beitragssatzdatei-Information
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public abstract Task<BeitragssatzdateiInfo> LoadInfoAsync(CancellationToken ct);

        /// <summary>
        /// Laden der Beitragssatzdatei
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public abstract Task<Beitragssatzdatei> LoadAsync(CancellationToken ct);
    }
}
