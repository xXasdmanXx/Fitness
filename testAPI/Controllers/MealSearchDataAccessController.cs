namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class MealSearchDataAccessController : DataAccessController
    {
        public List<FoodNutritions> Select(Search value)
        {
            List<FoodNutritions> res = new List<FoodNutritions>();
            try
            {
                this.cmd.Parameters.AddWithValue("@top", value.Top);
                this.cmd.Parameters.AddWithValue("@query", value.Query);
                this.cmd.CommandText = @"select top (@top) id, name, shortName, protein, fat, carbs, calories, water, sugar, cholesterol " + //, unit1, unit2, unit3 " +
                                       @"from FoodNutritions where name like concat('%',@query,'%');";
                
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                    {
                        //List<string> units = new List<string>();
                        //units.Add(Check(this.read.GetString(10)));
                        //units.Add(Check(this.read.GetString(11)));
                        //units.Add(Check(this.read.GetString(12)));
                        //units.TrimExcess();
                        res.Add(new FoodNutritions(
                            this.read.GetInt64(0),
                            this.Check(this.read.GetString(1)),
                            this.Check(this.read.GetString(2)),
                            this.read.GetDouble(3), // protein
                            this.read.GetDouble(4), // fat
                            this.read.GetDouble(5), // carbs
                            this.read.GetDouble(6), // calories
                            this.read.GetDouble(7), // water
                            this.read.GetDouble(8), // sugar
                            this.read.GetDouble(9)  // cholesterol
                            //,units
                            ));
                    }
                    return res;
                }
                else throw new Exception();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
            finally { this.EndQuery(); }
        }
    }
}