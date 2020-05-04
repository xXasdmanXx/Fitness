namespace FitnessApp.Models
{
    using System.Collections.Generic;

    public class DailyAll
    {
        public double Comsumed { get; set; }
        public double Remaining { get; set; }
        public double Burned { get; set; }
        public List<Met> Met { get; set; }
        public List<Food> Food { get; set; }
        public List<GpsExercise> GpsExercises { get; set; }

        public DailyAll(List<Met> met, List<Food> food, List<GpsExercise> gpsExercises, double height, double weight, string male, int goal, int age)
        {
            this.Met = met;
            this.Food = food;
            this.GpsExercises = gpsExercises;
            this.Food.ForEach(item => this.Comsumed += item.Quantity * item.Calories);

            foreach (Met item in this.Met)
                this.Burned += item.Duration * (item.MetNum * weight * 3.5) / 200.0;

            foreach (GpsExercise item in this.GpsExercises)
                this.Burned += item.Burned;

            double bmr = 0.0;
            if (male.Equals("male"))
                bmr = 66.46 + (13.7 * weight) + (5 * height) - (6.8 * age);
            else if (male.Equals("female"))
                bmr = 655.1 + (9.6 * weight) + (1.8 * height) - (4.7 * age);
            bmr *= 1.45;
            this.Burned += bmr;
            this.Remaining = this.Burned - this.Comsumed + goal;
        }
    }
}