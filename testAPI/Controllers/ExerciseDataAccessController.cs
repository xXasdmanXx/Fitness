namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ExerciseDataAccessController : DataAccessController
    {
        public ExerciseDataAccessController() : base() { }

        public bool Insert(Exercise e)
        {
            try
            {
                this.cmd.Parameters.AddWithValue("@personID", e.Person_ID);
                this.cmd.Parameters.AddWithValue("@metsID", e.Mets_ID);
                this.cmd.Parameters.AddWithValue("@date", e.Date);
                this.cmd.CommandText = "insert into Exercise(Person_ID, Mets_ID, Date) " +
                                       "values(@personID, @metsID, @date);";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                    this.cmd.ExecuteNonQuery();

                return true;
            }
            catch { return false; }
            finally { this.EndQuery(); }
        }

        public List<Exercise> Select()
        {
            List<Exercise> res = new List<Exercise>();
            try
            {
                this.cmd.CommandText = @"select * from Exercise";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                        res.Add(new Exercise(
                                    this.read.GetInt32(0), //["id"],
                                    this.read.GetInt32(1), //["Person_ID"],
                                    this.read.GetInt32(2), //["Mets_ID"],
                                    this.read.GetDateTime(3) //["Date"],
                                ));
                    return res;
                }
                else throw new Exception();
            }
            catch { return null; }
            finally { this.EndQuery(); }
        }
        public Exercise Select(int id)
        {
            List<Exercise> res = new List<Exercise>();
            try
            {
                this.cmd.CommandText = @"select * from Exercise where id = @id";
                this.cmd.Parameters.AddWithValue("@id", id);
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                        return new Exercise(
                                    this.read.GetInt32(0), //["id"],
                                    this.read.GetInt32(1), //["Person_ID"],
                                    this.read.GetInt32(2), //["Mets_ID"],
                                    this.read.GetDateTime(3) //["Date"],
                                    );
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
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "delete from Exercise where id = @id;";
                conn.Open();
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