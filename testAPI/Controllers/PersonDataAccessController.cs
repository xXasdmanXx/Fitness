namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class PersonDataAccessController : DataAccessController
    {
        public PersonDataAccessController() : base() { }

        public bool Insert(Person p)
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
                this.cmd.CommandText = "insert into Person(Name, Password, BirthDate, Height, Weight, Male, RegisterDate, Email) " +
                                    "values(@name, @pw, @birth, @height, @weight, @male, @reg, @mail);";
                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                    this.cmd.ExecuteNonQuery();
                else throw new Exception();

                return true;
            }
            catch { return false; }
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
                                    this.read.GetString(1), //["Name"],
                                    this.read.GetString(2), //["Password"],
                                    this.read.GetDateTime(3), //["BirthDate"],
                                    this.read.GetDouble(4), //["Height"],
                                    this.read.GetDouble(5), //["Weight"],
                                    this.read.GetString(6), //["Male"],
                                    this.read.GetDateTime(7), //["RegisterDate"],
                                    this.read.GetString(8) //["Email"] )
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
                                    this.read.GetString(1), //["Name"],
                                    this.read.GetString(2), //["Password"],
                                    this.read.GetDateTime(3), //["BirthDate"],
                                    this.read.GetDouble(4), //["Height"],
                                    this.read.GetDouble(5), //["Weight"],
                                    this.read.GetString(6), //["Male"],
                                    this.read.GetDateTime(7), //["RegisterDate"],
                                    this.read.GetString(8)); //["Email"] )
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