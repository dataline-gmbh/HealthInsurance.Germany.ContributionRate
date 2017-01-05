using System.Xml;

namespace Dataline.HealthInsurance.Germany.ContributionRate.V5_1
{
    /// <summary>
    /// Schnittstelle die für die Deserialisierung der Beitragssatzdatei implementiert werden muss
    /// </summary>
    public interface IDeserializer
    {
        /// <summary>
        /// Deserialisierung der Beitragssatzdatei
        /// </summary>
        /// <param name="reader">Das einzulesende XML-Dokument</param>
        /// <returns>Die deserialisierte Beitragssatzdatei</returns>
        Beitragssatzdatei Deserialize(XmlReader reader);
    }
}
