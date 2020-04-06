namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class PersonDataAccessController : DataAccessController
    {
        public int Insert(Person p)
        {
            try
            {
                this.cmd.Parameters.AddWithValue("@name", p.Name);
                this.cmd.Parameters.AddWithValue("@pw", p.Password);
                this.cmd.Parameters.AddWithValue("@birth", p.BirthDate);
                this.cmd.Parameters.AddWithValue("@height", p.Height);
                this.cmd.Parameters.AddWithValue("@weight", p.Weight);
                this.cmd.Parameters.AddWithValue("@male", p.Male);
                this.cmd.Parameters.AddWithValue("@reg", p.RegisterDate);
                this.cmd.Parameters.AddWithValue("@mail", p.Email);
                this.cmd.Parameters.AddWithValue("@goal", p.Goal);
                this.cmd.CommandText = "insert into Person(Name, Password, BirthDate, Height, Weight, Male, RegisterDate, Email, Goal) " +
                                    "values(@name, @pw, @birth, @height, @weight, @male, @reg, @mail, @goal);";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.cmd.ExecuteNonQuery();
                    this.conn.Close();
                }
                else throw new Exception();

                cmd.CommandText = @"select top 1 ID from Person where Email = @mail";
                this.conn.Open();
                this.read = this.cmd.ExecuteReader();

                return this.read.Read() ? read.GetInt32(0) : -1;
            }
            catch (Exception e){ System.Diagnostics.Debug.WriteLine("\n\n" + e.Message + "\n\n"); return -1; }
            finally { this.EndQuery(); }
        }

        public List<Person> Select()
        {
            List<Person> res = new List<Person>();
            try
            {
                this.cmd.CommandText = @"select * from Person";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                { 
                    this.read = this.cmd.ExecuteReader();
                    while (this.read.Read())
                        res.Add(new Person(
                                    this.read.GetInt32(0), //["ID"],
                                    this.Check(this.read.GetString(1)), //["Name"],
                                    this.Check(this.read.GetString(2)), //["Password"],
                                    this.read.GetDateTime(3), //["BirthDate"],
                                    this.read.GetDouble(4), //["Height"],
                                    this.read.GetDouble(5), //["Weight"],
                                    this.Check(this.read.GetString(6)), //["Male"],
                                    this.read.GetDateTime(7), //["RegisterDate"],
                                    this.Check(this.read.GetString(8)), //["Email"] )
                                    this.read.GetInt32(9)   // ["Goal"]
                                ));
                    return res;
                }
                else throw new Exception();
            }
            catch { return null; }
            finally { this.EndQuery(); }
        }
        public Person Select(int id)
        {
            List<Person> res = new List<Person>();
            try
            {
                this.cmd.CommandText = @"select * from Person where ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                this.conn.Open();
                if (conn.State.Equals(ConnectionState.Open))
                {
                    this.read = cmd.ExecuteReader();
                    while (this.read.Read())
                        return new Person(
                                    this.read.GetInt32(0), //["ID"],
                                    this.Check(this.read.GetString(1)), //["Name"],
                                    this.Check(this.read.GetString(2)), //["Password"],
                                    this.read.GetDateTime(3), //["BirthDate"],
                                    this.read.GetDouble(4), //["Height"],
                                    this.read.GetDouble(5), //["Weight"],
                                    this.Check(this.read.GetString(6)), //["Male"],
                                    this.read.GetDateTime(7), //["RegisterDate"],
                                    this.Check(this.read.GetString(8)), //["Email"] )
                                    this.read.GetInt32(9)   // ["Goal"]
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
                this.cmd.Parameters.AddWithValue("@id", id);
                this.cmd.CommandText = "delete from Person where ID = @id;";
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