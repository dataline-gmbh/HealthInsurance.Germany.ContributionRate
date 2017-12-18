using System;
using System.Xml.Serialization;

namespace Dataline.HealthInsurance.Germany.ContributionRate.V5_1
{
    // ReSharper disable once InconsistentNaming
    public partial class XmlDatei_Cpt
    {
        private static readonly System.Globalization.CultureInfo _cultureDE = new System.Globalization.CultureInfo("de-DE");

        /// <summary>
        /// Holt den Zeitstempel der Erstellung der Beitragssatzdatei
        /// </summary>
        [XmlIgnore]
        public DateTimeOffset? Timestamp
        {
            get
            {
                var time = TimeSpan.ParseExact(Uhrzeit, @"hh\:mm\:ss", _cultureDE);
                TimeZoneInfo info;
                try
                {
                    info = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
                }
                catch (Exception)
                {
                    info = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
                }

                var localDate = Datum.Add(time);
                var timeZoneOffset = info.GetUtcOffset(localDate);
                return new DateTimeOffset(localDate, timeZoneOffset);
            }
        }
    }
}
