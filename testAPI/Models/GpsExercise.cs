namespace FitnessApp.Models
{
    using System;

    public class GpsExercise
    {
        public int UserID { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public double Duration { get; set; }
        public double AvgSpeed { get; set; }
        public double Burned { get; set; }
        public GpsPath[] Path {get;set;}

        public GpsExercise(int userID, string type, DateTime start, double duration, double avgSpeed, double burned, GpsPath[] path)
        {
            this.UserID = userID;
            this.Type = type;
            this.Start = start;
            this.Duration = duration;
            this.AvgSpeed = avgSpeed;
            this.Burned = burned;
            this.Path = path;
        }

        public GpsExercise(int userID, string type, DateTime start, double duration, double avgSpeed, double burned)
        {
            this.UserID = userID;
            this.Type = type;
            this.Start = start;
            this.Duration = duration;
            this.AvgSpeed = avgSpeed;
            this.Burned = burned;
        }

    }
}