using System.Xml;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1
{
    public interface IDeserializer
    {
        Beitragssatzdatei Deserialize(XmlReader reader);
    }
}
