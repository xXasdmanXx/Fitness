namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ExerciseSearchDataAccessController : DataAccessController
    {
        public List<Mets> Select(Search value)
        {
            List<Mets> res = new List<Mets>();
            try
            {
                this.cmd.Parameters.AddWithValue("@top", value.Top);
                this.cmd.Parameters.AddWithValue("@query", value.Query);
                this.cmd.CommandText = @"select top (@top) ID, MET, Major, Detailed " +
                                       @"from Mets where Detailed like concat('%',@query,'%');";

                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                    {
                        res.Add(new Mets(
                            this.read.GetInt32(0),
                            this.read.GetDouble(1),
                            this.Check(this.read.GetString(2)),
                            this.Check(this.read.GetString(3))
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