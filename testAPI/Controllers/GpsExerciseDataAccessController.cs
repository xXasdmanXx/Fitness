namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Data;

    public class GpsExerciseDataAccessController : DataAccessController
    {
        public int Insert(GpsExercise g)
        {
            try
            {
                this.cmd.Parameters.AddWithValue("@userid", g.UserID);
                this.cmd.Parameters.AddWithValue("@type", g.Type);
                this.cmd.Parameters.AddWithValue("@Start", g.Start);
                this.cmd.Parameters.AddWithValue("@duration", g.Duration);
                this.cmd.Parameters.AddWithValue("@avgSpeed", g.AvgSpeed);
                this.cmd.Parameters.AddWithValue("@burned", g.Burned);

                this.cmd.CommandText = "insert into GpsExercise(userid, [type], [Start], duration, avgSpeed, burned) " +
                                        "values(@userid, @type, @Start, @duration, @avgSpeed, @burned);";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.cmd.ExecuteNonQuery();
                    this.conn.Close();
                }
                else throw new Exception("Connection is not open.");

                // get id of inserted element (GpsExercise row)
                cmd.CommandText = @"select Scope_Identity();";
                this.conn.Open();
                if(this.conn.State.Equals(ConnectionState.Open))
                {
                    int exerciseID = Convert.ToInt32(this.cmd.ExecuteScalar());
                    if (exerciseID > 0)
                    {
                        this.cmd.CommandText = "insert into GpsPath(exercise_id, latitude, longitude) " +
                                                "values(@exercise_id, @lat, @long);";
                        // running an insert on every path element with the queried exerciseID
                        foreach (var item in g.Path)
                        {
                            this.cmd.Parameters.Clear();
                            this.cmd.Parameters.AddWithValue("@exercise_id", exerciseID);
                            this.cmd.Parameters.AddWithValue("@lat", item.Lat);
                            this.cmd.Parameters.AddWithValue("@long", item.Lng);

                            this.cmd.ExecuteNonQuery();
                        }
                        this.conn.Close();
                    }
                    else throw new Exception("Cannot query id of inserted element (GpsExercise).");
                }
                else throw new Exception("Connection is not open.");

                return 1;
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine("\n\n" + e.Message + "\n\n"); return 0; }
            finally { this.EndQuery(); }
        }
    }
}