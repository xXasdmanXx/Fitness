namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class DailyDataAccessController : DataAccessController
    {
        public DailyAll Select(Daily value)
        {
            List<Met> tmpMet = new List<Met>();
            double weight = 0;
            int goal = 0;
            try
            {
                this.cmd.Parameters.AddWithValue("@id", value.ID);
                this.cmd.Parameters.AddWithValue("@date", value.Date);
                this.cmd.CommandText = @"select Exercise.id, Mets.MET, Mets.Detailed, Exercise.Duration, Exercise.[Date] " +
                                        @"from Exercise inner join Mets on Mets.ID = Exercise.Mets_ID " +
                                        @"where Exercise.Person_ID = @id and cast(Exercise.[Date] as date) = convert(date, @date)";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                        tmpMet.Add(new Met(
                                this.read.GetInt32(0),  // ["ID"]
                                this.read.GetDouble(1),  // ["MET"]
                                this.Check(this.read.GetString(2)),  // ["Detailed"]
                                this.read.GetDouble(3),  // ["Duration"]
                                this.read.GetDateTime(4)    // ["Date"]
                                ));
                }
                else throw new Exception();

                this.conn.Close();

                this.cmd.CommandText = @"select top 1 Weight, Goal from Person where ID = @id";
                this.conn.Open();
                if(this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    if(this.read.Read())
                    {
                        weight = this.read.GetDouble(0);
                        goal = this.read.GetInt32(1);
                    }
                }

                this.conn.Close();

                this.cmd.CommandText = @"select Meal.id, Meal.Quantity, FoodNutritions.name, FoodNutritions.calories, FoodNutritions.carbs, FoodNutritions.fat, FoodNutritions.protein, Meal.[Date] " +
                                       @"from Meal inner join FoodNutritions on Meal.FoodNutritions_ID = FoodNutritions.id " +
                                       @"where Meal.Person_ID = @id and cast(Meal.[Date] as date) = convert(date, @date)";
                List<Food> tmpFood = new List<Food>();
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                        tmpFood.Add(new Food(
                            this.read.GetInt32(0),
                            this.read.GetDouble(1),
                            this.read.GetString(2),
                            this.read.GetDouble(3),
                            this.read.GetDouble(4),
                            this.read.GetDouble(5),
                            this.read.GetDouble(6),
                            this.read.GetDateTime(7)));
                }
                else throw new Exception();

                tmpMet.TrimExcess();
                tmpFood.TrimExcess();
                return new DailyAll(tmpMet, tmpFood, weight, goal);
            }
            catch(Exception e) { System.Diagnostics.Debug.WriteLine(e.Message); return null; }
            finally { this.EndQuery(); }
        }
    }
}