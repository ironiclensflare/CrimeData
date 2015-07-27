using System;

namespace Ironiclensflare.CrimeData
{
    public class Crime
    {
        public CrimeCategory Category { get; set; }
        public DateTime Month { get; set; }
        public CrimeLocation Location { get; set; }
        public CrimeOutcome Outcome { get; set; }
    }

    public class CrimeDataset
    {
        public DateTime Date { get; set; }
    }

    public class CrimeCategory
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }

    public class CrimeLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public CrimeStreet Street { get; set; }
    }

    public class CrimeStreet
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CrimeOutcome
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}
