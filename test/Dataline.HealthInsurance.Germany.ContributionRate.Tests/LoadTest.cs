using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace Dataline.HealthInsurance.ContributionRateImport.Tests
{
    public class LoadTest
    {
        private static readonly CultureInfo _cultureDE = new CultureInfo("de-DE");

        [Fact]
        public async Task TestLoadV5()
        {
            var doc = await Loaders.LoadTestV5_1Async();

            Assert.NotNull(doc);
            Assert.NotNull(doc.HDR);
            Assert.NotNull(doc.HDR.XML_Datei.Timestamp);
            Assert.Equal("ITSG GmbH", doc.HDR.Ersteller);
            Assert.NotNull(doc.HDR.XML_Datei);
            Assert.Equal("EBSD0-GES_V51_2016_0211.XML", doc.HDR.XML_Datei.Dateiname);
            Assert.NotNull(doc.ADR);
            Assert.Equal(1, doc.ADR.Count(x => x.bn == "01011777"));
            var adr = doc.ADR.Single(x => x.bn == "01011777");
            Assert.Equal("BKK GILDEMEISTER SEIDENSTICKER-Ost", adr.Kurzbezeichnung);

            Assert.NotNull(doc.KIBS);
            var kibs = doc.KIBS.Where(x => x.bn == "33868451").ToList();
            Assert.Equal(1, kibs.Count);
            Assert.Equal(new DateTime(2015, 1, 1), kibs.First().ZS_gueltig_ab);
            Assert.Equal(0.9m, decimal.Parse(kibs.First().Beitragssatz.Value, _cultureDE));

            Assert.NotNull(doc.DAV);
            Assert.Equal(1, doc.DAV.Count(x => x.bn == "01000240"));

            var dupeAddresses = doc.ADR.GroupBy(x => x.bn)
                .Where(x => x.Count() != 1)
                .Select(x => x.Key)
                .ToList();
            Assert.Equal(0, dupeAddresses.Count);

            Assert.NotNull(doc.UME);
            var dupeUme = doc.UME.GroupBy(x => new { x.bn, x.gueltig_ab })
                .Where(x => x.Count() != 1)
                .Select(x => x.Key)
                .ToList();
            Assert.Equal(0, dupeUme.Count);

            // Im Bereich KIBS dürfen mehrere Einträge vorkommen?
            var dupeKibs = doc.KIBS.GroupBy(x => new { x.bn, x.ZS_gueltig_ab })
                .Where(x => x.Count() != 1)
                .Select(x => x.Key)
                .ToList();
            Assert.Equal(0, dupeKibs.Count);

            var dupeDav = doc.DAV.GroupBy(x => x.bn)
                .Where(x => x.Count() != 1)
                .Select(x => x.Key)
                .ToList();
            Assert.Equal(0, dupeDav.Count);
        }
    }
}
