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
                this.cmd.CommandText = @"select top (@top) name, shortName, protein, fat, carbs, calories, water, sugar, cholesterol, unit1, unit2, unit3 " +
                                       @"from FoodNutritions where name like concat('%',@query,'%');";
                
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                    {
                        List<string> units = new List<string>();
                        units.Add(Check(read.GetString(9)));
                        units.Add(Check(read.GetString(10)));
                        units.Add(Check(read.GetString(11)));
                        units.TrimExcess();
                        res.Add(new FoodNutritions(
                            Check(read.GetString(0)),
                            Check(read.GetString(1)),
                            read.GetDouble(2),
                            read.GetDouble(3),
                            read.GetDouble(4),
                            read.GetDouble(5),
                            read.GetDouble(6),
                            read.GetDouble(7),
                            read.GetDouble(8),
                            units
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

        private string Check(string str)
        {
            return (str.Trim() == null || str.Trim() == "" || str.Trim() == "NULL") ? string.Empty : str;
        }
    }
}