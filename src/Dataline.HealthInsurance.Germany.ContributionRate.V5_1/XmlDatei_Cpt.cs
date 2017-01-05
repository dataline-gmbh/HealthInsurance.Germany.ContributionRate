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
#if PCL
                var localTimestamp = new DateTime(Datum.Year, Datum.Month, Datum.Day, time.Hours, time.Minutes, time.Seconds, DateTimeKind.Local);
                return new DateTimeOffset(localTimestamp);
#else
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
#endif
            }
        }
    }
}
