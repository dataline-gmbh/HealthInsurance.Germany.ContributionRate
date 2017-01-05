using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dataline.HealthInsurance.Germany.ContributionRate.V5_1.Loaders
{
    /// <summary>
    /// Laden der Beitragssatzdatei aus einem Stream
    /// </summary>
    public class StreamLoader : IStreamingLoader
    {
        private readonly IDeserializer _deserializer;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="StreamLoader"/> Klasse.
        /// </summary>
        /// <param name="deserializer">Der zu verwendende <see cref="IDeserializer"/></param>
        public StreamLoader(IDeserializer deserializer)
        {
            _deserializer = deserializer;
        }

        /// <inheritdoc/>
        public Task<Beitragssatzdatei> LoadAsync(Stream stream, CancellationToken ct)
        {
            var doc = XDocument.Load(stream);
            return Task.FromResult(_deserializer.Deserialize(doc.CreateReader()));
        }
    }
}
