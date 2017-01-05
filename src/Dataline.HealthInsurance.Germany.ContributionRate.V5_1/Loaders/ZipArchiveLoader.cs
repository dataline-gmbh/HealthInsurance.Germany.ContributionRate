using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1.Loaders
{
    /// <summary>
    /// Laden der Beitragssatzdatei(en) aus einer ZIP-Datei
    /// </summary>
    public class ZipArchiveLoader : IStreamingLoader
    {
        private readonly IDeserializer _deserializer;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="ZipArchiveLoader"/>-Klasse.
        /// </summary>
        /// <param name="deserializer">Der zu verwendende <see cref="IDeserializer"/></param>
        public ZipArchiveLoader(IDeserializer deserializer)
        {
            _deserializer = deserializer;
        }

        /// <inheritdoc/>
        public Task<Beitragssatzdatei> LoadAsync(Stream stream, CancellationToken ct)
        {
            using (var archive = new System.IO.Compression.ZipArchive(stream, System.IO.Compression.ZipArchiveMode.Read, true))
            {
                foreach (var entry in archive.Entries.Where(x => !string.IsNullOrEmpty(x.Name)))
                {
                    ct.ThrowIfCancellationRequested();
                    using (var entryStream = entry.Open())
                    {
                        var doc = XDocument.Load(entryStream);
                        return Task.FromResult(_deserializer.Deserialize(doc.CreateReader()));
                    }
                }
            }

            throw new InvalidOperationException("Die ZIP-Datei enthält keine Daten.");
        }
    }
}
