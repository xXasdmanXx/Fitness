namespace FitnessApp.Models
{
    using System;
    using System.Text;

    public class Meal
    {
        public int ID { get; set; }
        public int Person_ID { get; set; }
        public int FoodNutritions_ID { get; set; }
        public double Quantity { get; set; }
        public DateTime Date { get; set; }

        public Meal(int id, int personID, int foodNutritionsID, double quantity, DateTime date)
        {
            this.ID = id;
            this.Person_ID = personID;
            this.FoodNutritions_ID = foodNutritionsID;
            this.Quantity = quantity;
            this.Date = date;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder("\nID: ");
            b.Append(this.ID);
            b.Append("\tPerson_ID: "); b.Append(this.Person_ID);
            b.Append("\tFoodNutritions_ID: "); b.Append(this.FoodNutritions_ID);
            b.Append("\tQuantity: "); b.Append(this.Quantity);
            b.Append("\tDate: "); b.Append(this.Date);
            b.Append('\n');
            return b.ToString();
        }
    }
}