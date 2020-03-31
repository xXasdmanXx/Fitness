namespace FitnessApp.Controllers
{
    using Models;
    using System;
    using System.Data;

    public class LogInCredentialsDataAccessController : DataAccessController
    {
        public Person Select(LogInCredentials value)
        {
            try
            {
                this.cmd.CommandText = @"select top 1 * from Person where Password = @pw and Email = @mail";
                this.cmd.Parameters.AddWithValue("@pw", value.Password);
                this.cmd.Parameters.AddWithValue("@mail", value.Mail);

                this.conn.Open();
                if (this.conn.State.Equals(ConnectionState.Open))
                {
                    this.read = this.cmd.ExecuteReader();
                    if (this.read.Read())
                        return new Person(
                            this.read.GetInt32(0),
                            this.Check(this.read.GetString(1)),
                            this.Check(this.read.GetString(2)),
                            this.read.GetDateTime(3),
                            this.read.GetDouble(4),
                            this.read.GetDouble(5),
                            this.Check(this.read.GetString(6)),
                            this.read.GetDateTime(7),
                            this.Check(this.read.GetString(8))
                            );
                    else
                        return null;
                }
                else
                    throw new Exception("Connection is not open.");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("\n\n" + e.Message + "\n\n");
                return null;
            }
            finally { this.EndQuery(); }
        }
    }
}