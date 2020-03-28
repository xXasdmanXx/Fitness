namespace FitnessApp.Models
{
    using System;

    public class Met
    {
        public double MetNum { get; set; }
        public string Detailed { get; set; }
        public double Duration { get; set; }
        public DateTime Date { get; set; }

        public Met(double metNum, string detailed, double duration, DateTime date)
        {
            this.MetNum = metNum;
            this.Detailed = detailed;
            this.Duration = duration;
            this.Date = date;
        }
    }
}