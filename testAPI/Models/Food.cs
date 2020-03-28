namespace FitnessApp.Models
{
    using System;

    public class Food
    {
        public double Quantity { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Unit3 { get; set; }
        public DateTime Date { get; set; }

        public Food(double q, string n, double cal, double ca, double fa, double pr, string u1, string u2, string u3, DateTime date)
        {
            this.Quantity = q;
            this.Name = n;
            this.Calories = cal;
            this.Carbs = ca;
            this.Fat = fa;
            this.Protein = pr;
            this.Unit1 = u1;
            this.Unit2 = u2;
            this.Unit3 = u3;
            this.Date = date;
        }
    }
}