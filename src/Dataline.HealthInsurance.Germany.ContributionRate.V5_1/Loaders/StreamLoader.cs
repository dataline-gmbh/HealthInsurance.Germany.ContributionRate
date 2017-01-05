using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1.Loaders
{
    /// <summary>
    /// Laden der Beitragssatzdatei aus einem Stream
    /// </summary>
    public class StreamLoader : ILocalLoader
    {
        private readonly IDeserializer _deserializer;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="deserializer"></param>
        public StreamLoader(IDeserializer deserializer)
        {
            _deserializer = deserializer;
        }

        /// <summary>
        /// Laden der Beitragssatzdatei
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<Beitragssatzdatei> LoadAsync(Stream stream, CancellationToken ct)
        {
            var doc = XDocument.Load(stream);
            return Task.FromResult(_deserializer.Deserialize(doc.CreateReader()));
        }
    }
}
