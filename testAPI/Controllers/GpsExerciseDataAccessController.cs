namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

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
                cmd.CommandText = @"select top 1 id from GpsExercise order by start desc";
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

        public GpsExercise Select(int id)
        {
            try
            {
                List<GpsPath> paths = new List<GpsPath>();
                cmd.Parameters.AddWithValue("@id", id);
                this.cmd.CommandText = @"select latitude, longitude from GpsPath where exercise_id = @id;";
                this.conn.Open();
                if (conn.State.Equals(ConnectionState.Open))
                {
                    this.read = cmd.ExecuteReader();
                    while (this.read.Read())
                        paths.Add(new GpsPath(this.read.GetDouble(0), this.read.GetDouble(1)));
                    conn.Close();

                    this.cmd.CommandText = @"select userid, type, start, duration, avgSpeed, burned " +
                                           @"from GpsExercise where id = @id;";
                    this.conn.Open();
                    if (conn.State.Equals(ConnectionState.Open))
                    {
                        this.read = cmd.ExecuteReader();
                        while (this.read.Read())
                            return new GpsExercise(
                                    this.read.GetInt32(0), // userid
                                    this.Check(this.read.GetString(1)), // type
                                    this.read.GetDateTime(2),   // start
                                    Math.Round(this.read.GetFloat(3),5), // duration
                                    Math.Round(this.read.GetFloat(4),5),  // avgSpeed
                                    Math.Round(this.read.GetFloat(5),5),   // burned
                                    paths.ToArray() // path
                                   );
                        throw new Exception("Cannot read from database.");
                    }
                    else throw new Exception("Cannot open connection.");
                }
                else throw new Exception("Cannot open connection.");
            }
            catch (Exception e){ System.Diagnostics.Debug.WriteLine("\n\n{0}\n\n", e.Message); return null; }
            finally { this.EndQuery(); }
        }

        public List<GpsExercise> SelectAll(int id)
        {
            List<GpsExercise> res = new List<GpsExercise>();

            try
            {
                cmd.Parameters.AddWithValue("@id", id);
                this.cmd.CommandText = @"select id, type, start, duration, avgSpeed, burned " +
                                        @"from GpsExercise where userid = @id;";
                this.conn.Open();
                if (conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                    {
                        /* USERID contains tha actual ID of Exercise in this case */
                        int userID = this.read.GetInt32(0);
                        string type = this.Check(this.read.GetString(1)); // type
                        DateTime start = this.read.GetDateTime(2);   // start
                        double duration = Math.Round(this.read.GetFloat(3), 5); // duration
                        double avgSpeed = Math.Round(this.read.GetFloat(4), 5);  // avgSpeed
                        double burned = Math.Round(this.read.GetFloat(5), 5);   // burned

                        res.Add(new GpsExercise(userID, type, start, duration, avgSpeed, burned, new GpsPath[0] ));
                    }
                    this.conn.Close();

                    this.cmd.CommandText = @"select latitude, longitude from GpsPath where exercise_id = @id";
                    foreach (GpsExercise item in res)
                    {
                        this.cmd.Parameters.Clear();
                        this.cmd.Parameters.AddWithValue("@id", item.UserID);

                        this.conn.Open();
                        if (conn.State.Equals(ConnectionState.Open))
                        {
                            SqlDataReader r = this.cmd.ExecuteReader();
                            List<GpsPath> paths = new List<GpsPath>();
                            while (r.Read())
                                paths.Add(new GpsPath(r.GetDouble(0), r.GetDouble(1)));
                            this.conn.Close();
                            item.Path = paths.ToArray();
                        }
                        else throw new Exception("Cannot open connection.");
                    }
                    return res;
                }
                else throw new Exception("Cannot open connection.");
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine("\n\n{0}\n\n", e.Message); return null; }
            finally { this.EndQuery(); }
        }

        public bool Delete(int id)
        {
            try
            {
                this.cmd.Parameters.AddWithValue("@id", id);
                this.cmd.CommandText = "delete from GpsExercise where id = @id;";
                this.conn.Open();
                if (conn.State.Equals(ConnectionState.Open))
                    this.cmd.ExecuteNonQuery();
                else throw new Exception("\n\nCannot delete from GpsExercise.\n\n");

                return true;
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine("\n\n{0}\n\n", e.Message); return false; }
            finally { this.EndQuery(); }
        }
    }
}