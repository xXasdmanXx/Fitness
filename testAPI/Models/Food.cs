namespace FitnessApp.Models
{
    using System;

    public class Food
    {
        public int ID { get; set; }
        public double Quantity { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public DateTime Date { get; set; }

        public Food(int id, double q, string n, double cal, double ca, double fa, double pr, DateTime date)
        {
            this.ID = id;
            this.Quantity = q;
            this.Name = n;
            this.Calories = cal;
            this.Carbs = ca;
            this.Fat = fa;
            this.Protein = pr;
            this.Date = date;
        }
    }
}