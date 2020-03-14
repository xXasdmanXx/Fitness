namespace FitnessApp.Controllers
{
    using System.Data.SqlClient;

    public class DataAccessController
    {
        protected readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
            System.AppDomain.CurrentDomain.BaseDirectory + "Fitness.mdf;Integrated Security=True;Connect Timeout=30";
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader read;
        
        public DataAccessController()
        {
            this.conn = new SqlConnection(this.connectionString);
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            System.Diagnostics.Debug.WriteLine("\n\nConnection string is: " + connectionString + "\n\n");
        }

        protected void EndQuery()
        {
            this.conn.Close();
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = string.Empty;
            this.read = null;
        }
    }
}