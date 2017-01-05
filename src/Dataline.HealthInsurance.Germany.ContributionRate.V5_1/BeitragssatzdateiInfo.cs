using System;
using System.Text.RegularExpressions;

namespace Dataline.HealthInsurance.ContributionRateImport.V5_1
{
    /// <summary>
    /// Informationen über eine Beitragssatzdatei
    /// </summary>
    public class BeitragssatzdateiInfo
    {
        private static readonly System.Globalization.CultureInfo _cultureDE = new System.Globalization.CultureInfo("de-DE");

        private static readonly Regex _bsdFileNameRegEx = new Regex(@"(?<test>[ET])BSD0-(?<type>(GES))(_V(?<version>[0-9]{2}))_(?<year>[0-9]{4})_(?<month>[0-9]{2})(?<day>[0-9]{2})\.(?<format>(ZIP)|(XML))", RegexOptions.IgnoreCase);

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public BeitragssatzdateiInfo(string fileName, long? length)
        {
            Length = length;

            var match = _bsdFileNameRegEx.Match(fileName);
            if (!match.Success)
                throw new ArgumentException("Der Dateiname muss ein gültiger BSD-Dateiname sein.", nameof(fileName));

            FileName = fileName;
            IsTest = string.Equals(match.Groups["test"].Value, "T", StringComparison.OrdinalIgnoreCase);

            var year = int.Parse(match.Groups["year"].Value, _cultureDE);
            var month = int.Parse(match.Groups["month"].Value, _cultureDE);
            var day = int.Parse(match.Groups["day"].Value, _cultureDE);
            Timestamp = new DateTime(year, month, day);

            var versionGroup = match.Groups["version"];
            var version = int.Parse(versionGroup.Value, _cultureDE);
            Version = new Version(version / 10, version % 10);

            Format = match.Groups["format"].Value;
        }

        /// <summary>
        /// Test-Daten?
        /// </summary>
        public bool IsTest { get; }

        /// <summary>
        /// Zeitstempel der letzten Änderung
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Datei-Name
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Version der Beitragssatzdatei
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Die Länge der Beitragssatzdatei
        /// </summary>
        public long? Length { get; }

        /// <summary>
        /// Holt das Dateiformat
        /// </summary>
        public string Format { get; }
    }
}
