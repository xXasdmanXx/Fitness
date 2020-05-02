namespace FitnessApp.Models
{
    using System;
    using System.Collections.Generic;

    public class GpsExercise
    {
        public int UserID { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public float Duration { get; set; }
        public float AvgSpeed { get; set; }
        public float Burned { get; set; }
        public GpsPath[] Path {get;set;}

        public GpsExercise(int userID, string type, DateTime start, float duration, float avgSpeed, float burned, GpsPath[] path)
        {
            this.UserID = userID;
            this.Type = type;
            this.Start = start;
            this.Duration = duration;
            this.AvgSpeed = avgSpeed;
            this.Burned = burned;
            this.Path = path;
        }
    }
}