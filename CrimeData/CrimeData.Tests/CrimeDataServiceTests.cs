using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FakeItEasy;
using Ironiclensflare.CrimeData;

namespace CrimeData.Tests
{
    [TestFixture]
    public class CrimeDataServiceTests
    {
        [Ignore]
        [TestCase(false, new[] { "2015-01", "2015-09", "2014-03", "2013-12" })]
        [TestCase(false, new[] { "2013-12", "2014-03", "2015-01", "2015-09" })]
        public void GetAvailableDatasets_WhenCalled_ReturnsListSortedByDate(bool unused, string[] dates)
        {
            var fakeDatasetsService = A.Fake<IAvailableDatasetsService>();
            var fakeDatasets = dates.Select(d => new CrimeDataset { Date = DateTime.Parse(d) });
            A.CallTo(() => fakeDatasetsService.DownloadListOfDatasets()).Returns(fakeDatasets);
            var crimeDataService = new CrimeDataService(fakeDatasetsService);
            var correctlySortedDatasets =
                dates.Select(d => new CrimeDataset { Date = DateTime.Parse(d) }).OrderBy(d => d.Date);

            var datasets = crimeDataService.GetAvailableDatasets();

            Assert.True(datasets.SequenceEqual(correctlySortedDatasets));
        }
    }
}
