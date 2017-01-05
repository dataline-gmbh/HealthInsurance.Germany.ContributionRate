using System;
using System.Xml;
using System.Xml.Serialization;

namespace Dataline.HealthInsurance.Germany.ContributionRate.V5_1
{
    /// <summary>
    /// Die Standard-Implementation der Deserialisierung der Beitragssatzdatei
    /// </summary>
    public class BeitragssatzdateiDeserializer : IDeserializer
    {
        private readonly Lazy<XmlSerializer> _serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(Beitragssatzdatei)));

        /// <inheritdoc/>
        public Beitragssatzdatei Deserialize(XmlReader reader)
        {
            return (Beitragssatzdatei)_serializer.Value.Deserialize(reader);
        }
    }
}
