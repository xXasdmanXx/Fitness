namespace FitnessApp.Models
{
    //using System.Collections.Generic;
    using System.Text;

    public class FoodNutritions
    {
        #region Properties
        public long ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double Protein { get; set; }      // (g / 100g)
        public double Fat { get; set; }          // (g / 100g)
        public double Carbs { get; set; }        // (g / 100g)
        public double Calories { get; set; }     // (kcal / 100g)
        public double Water { get; set; }        // (g / 100g)
        public double Sugar { get; set; }        // (g / 100g)
        public double Cholesterol { get; set; }  // (mg / 100g)
//        public List<string> Units { get; set; }
        #endregion Properties

        public FoodNutritions(string name, string shortName,
                    double protein, double fat, double carbs, double calories, 
                    double water, double sugar, double cholesterol) //, List<string> units)
        {
            this.Name = name;
            this.ShortName = shortName;
            this.Protein = protein;
            this.Fat = fat;
            this.Carbs = carbs;
            this.Calories = calories;
            this.Water = water;
            this.Sugar = sugar;
            this.Cholesterol = cholesterol;
            //this.Units = units;
        }
        public FoodNutritions(long id, string name, string shortName,
                    double protein, double fat, double carbs, double calories,
                    double water, double sugar, double cholesterol)//, List<string> units)
        {
            this.ID = id;
            this.Name = name;
            this.ShortName = shortName;
            this.Protein = protein;
            this.Fat = fat;
            this.Carbs = carbs;
            this.Calories = calories;
            this.Water = water;
            this.Sugar = sugar;
            this.Cholesterol = cholesterol;
            //this.Units = units;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("\nName: "); b.Append(this.Name);
            b.Append("\tShortName: "); b.Append(this.ShortName);
            b.Append("\tProtein: "); b.Append(this.Protein);
            b.Append("\tFat: "); b.Append(this.Fat);
            b.Append("\tCarbs: "); b.Append(this.Carbs);
            b.Append("\tCalories: "); b.Append(this.Calories);
            b.Append("\tWater: "); b.Append(this.Water);
            b.Append("\tSugar: "); b.Append(this.Sugar);
            b.Append("\tCholesterol: "); b.Append(this.Cholesterol);
            //b.Append("\tUNITS: ");
            //foreach (string unit in this.Units)
            //{
            //    b.Append(unit);
            //    b.Append(",");
            //}
            //b.Remove(b.Length - 1, 1);
            b.Append("\n");
            return b.ToString();
        }
    }
}
