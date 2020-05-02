namespace FitnessApp.Models
{
    using System.Data.SqlTypes;

    public class GpsPath
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        public GpsPath(double lat, double lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}