namespace FitnessApp.Models
{
    public class GpsPath
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }

        public GpsPath(decimal lat, decimal lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}