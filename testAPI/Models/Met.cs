namespace FitnessApp.Models
{
    public class Met
    {
        public double MetNum { get; set; }
        public string Detailed { get; set; }

        public Met(double metNum, string detailed)
        {
            this.MetNum = metNum;
            this.Detailed = detailed;
        }
    }
}