using System;
using System.Xml;
using System.Xml.Serialization;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1
{
    public class BeitragssatzdateiDeserializer : IDeserializer
    {
        private readonly Lazy<XmlSerializer> _serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(Beitragssatzdatei)));

        public Beitragssatzdatei Deserialize(XmlReader reader)
        {
            return (Beitragssatzdatei)_serializer.Value.Deserialize(reader);
        }
    }
}
