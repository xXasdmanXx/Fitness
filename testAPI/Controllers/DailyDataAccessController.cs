namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class DailyDataAccessController : DataAccessController
    {
        public DailyDataAccessController() : base() { }

        public DailyAll Select(Daily value)
        {
            List<Met> tmpMet = new List<Met>();
            double weight = 0;
            try
            {
                this.cmd.Parameters.AddWithValue("@id", value.ID);
                this.cmd.Parameters.AddWithValue("@date", value.Date);
                this.cmd.CommandText = @"select Mets.MET, Mets.Detailed, Exercise.Duration, Exercise.[Date] " +
                                        @"from Exercise inner join Mets on Mets.ID = Exercise.Mets_ID " +
                                        @"where Exercise.Person_ID = @id and Exercise.[Date] = convert(date, @date)";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                        tmpMet.Add(new Met(
                                this.read.GetDouble(0),  // ["MET"]
                                this.Check(this.read.GetString(1)),  // ["Detailed"]
                                this.read.GetDouble(2),  // ["Duration"]
                                this.read.GetDateTime(3)    // ["Date"]
                                ));
                }
                else throw new Exception();

                this.conn.Close();

                this.cmd.CommandText = @"select Weight from Person where ID = @id";
                this.conn.Open();
                if(this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while(this.read.Read())
                        weight = this.read.GetDouble(0);
                }

                this.conn.Close();

                this.cmd.CommandText = @"select Meal.Quantity, 
		FoodNutritions.name, FoodNutritions.calories, FoodNutritions.carbs, FoodNutritions.fat, 
		FoodNutritions.protein, FoodNutritions.unit1, FoodNutritions.unit2, FoodNutritions.unit3, Meal.[Date] " +
                                       @"from Meal inner join FoodNutritions on Meal.FoodNutritions_ID = FoodNutritions.id " +
                                       @"where Meal.Person_ID = @id and Meal.[Date] = convert(date, @date)";
                List<Food> tmpFood = new List<Food>();
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                        tmpFood.Add(new Food(
                            this.read.GetDouble(0),
                            this.read.GetString(1),
                            this.read.GetDouble(2),
                            this.read.GetDouble(3),
                            this.read.GetDouble(4),
                            this.read.GetDouble(5),
                            this.Check(this.read.GetString(6)),
                            this.Check(this.read.GetString(7)),
                            this.Check(this.read.GetString(8)),
                            this.read.GetDateTime(9)));
                }
                else throw new Exception();

                tmpMet.TrimExcess();
                tmpFood.TrimExcess();
                return new DailyAll(tmpMet, tmpFood, weight);
            }
            catch(Exception e) { System.Diagnostics.Debug.WriteLine(e.Message); return null; }
            finally { this.EndQuery(); }
        }
    }
}