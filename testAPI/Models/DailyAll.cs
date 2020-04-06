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

        public DailyAll(List<Met> met, List<Food> food, double weight, int goal)
        {
            this.Met = met;
            this.Food = food;
            this.Food.ForEach(item => this.Comsumed += item.Quantity * item.Calories);

            foreach (Met item in this.Met)
                this.Burned += item.Duration * (item.MetNum * weight * 3.5) / 200.0;

            this.Remaining = this.Comsumed - this.Burned + goal;
        }
    }
}