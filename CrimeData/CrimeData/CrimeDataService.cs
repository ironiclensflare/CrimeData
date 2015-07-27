using System;
using System.Collections.Generic;
using System.Linq;

namespace Ironiclensflare.CrimeData
{
    public class CrimeDataService
    {
        private readonly IAvailableDatasetsService _datasetsService;

        public CrimeDataService(IAvailableDatasetsService service)
        {
            _datasetsService = service;
        }

        public IEnumerable<CrimeDataset> GetAvailableDatasets()
        {
            var datasets = _datasetsService.DownloadListOfDatasets();
            datasets = datasets.OrderBy(d => d.Date);
            return datasets;
        }
    }

    public class AvailableDatasetsService : IAvailableDatasetsService
    {
        public IEnumerable<CrimeDataset> DownloadListOfDatasets()
        {
            throw new NotImplementedException();
        }
    }

    public interface IAvailableDatasetsService
    {
        IEnumerable<CrimeDataset> DownloadListOfDatasets();
    }
}
