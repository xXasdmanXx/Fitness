namespace FitnessApp.Models
{
    using System.Collections.Generic;

    public class DailyAll
    {
        public List<Met> Met { get; set; }
        public List<Food> Food { get; set; }

        public DailyAll(List<Met> met, List<Food> food)
        {
            this.Met = met;
            this.Food = food; 
        }
    }
}