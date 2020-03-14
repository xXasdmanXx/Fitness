namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class MealDataAccessController : DataAccessController
    {
        public MealDataAccessController() : base() { }

        public bool Insert(Meal m)
        {
            try
            {
                this.cmd.Parameters.AddWithValue("@pID", m.Person_ID);
                this.cmd.Parameters.AddWithValue("@fID", m.FoodNutritions_ID);
                this.cmd.Parameters.AddWithValue("@quantity", m.Quantity);
                this.cmd.Parameters.AddWithValue("@date", m.Date);
                this.cmd.CommandText = "insert into Meal(Person_ID, FoodNutritions_ID, Quantity, Date) " +
                                       "values(@pID, @fID, @quantity, @date)";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                    this.cmd.ExecuteNonQuery();
                else throw new Exception();

                return true;
            }
            catch { return false; }
            finally { this.EndQuery(); }
        }

        public List<Meal> Select()
        {
            List<Meal> res = new List<Meal>();
            try
            {
                this.cmd.CommandText = @"select * from Meal";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                        res.Add(new Meal(
                                    this.read.GetInt32(0), //["Iid],
                                    this.read.GetInt32(1), //["Person_ID"],
                                    this.read.GetInt32(2), //["FoodNutritions_ID"],
                                    this.read.GetDouble(3), //["Quantity"],
                                    this.read.GetDateTime(4) //["Data"],
                                ));
                    return res;
                }
                else throw new Exception();
            }
            catch { return null; }
            finally { this.EndQuery(); }
        }
        public Meal Select(int id)
        {
            List<Meal> res = new List<Meal>();
            try
            {
                this.cmd.CommandText = @"select * from Meal where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                this.conn.Open();
                if (conn.State.Equals(ConnectionState.Open))
                {
                    this.read = cmd.ExecuteReader();
                    while (this.read.Read())
                        return new Meal(
                                    this.read.GetInt32(0), //["ID"],
                                    this.read.GetInt32(1), //["Person_ID"],
                                    this.read.GetInt32(2), //["FoodNutritions_ID"],
                                    this.read.GetDouble(3), //["Quantity"],
                                    this.read.GetDateTime(4)); //["Data"]
                    return null;
                }
                else throw new Exception();
            }
            catch { return null; }
            finally { this.EndQuery(); }
        }

        public bool Delete(int id)
        {
            try
            {
                this.cmd.Parameters.AddWithValue("@id", id);
                this.cmd.CommandText = "delete from Meal where ID = @id;";
                this.conn.Open();
                if (conn.State.Equals(ConnectionState.Open))
                    this.cmd.ExecuteNonQuery();
                else throw new Exception();

                return true;
            }
            catch { return false; }
            finally { this.EndQuery(); }
        }
    }
}