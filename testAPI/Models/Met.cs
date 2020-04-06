namespace FitnessApp.Models
{
    using System;

    public class Met
    {
        public int ID { get; set; }
        public double MetNum { get; set; }
        public string Detailed { get; set; }
        public double Duration { get; set; }
        public DateTime Date { get; set; }

        public Met(int id, double metNum, string detailed, double duration, DateTime date)
        {
            this.ID = id;
            this.MetNum = metNum;
            this.Detailed = detailed;
            this.Duration = duration;
            this.Date = date;
        }
    }
}