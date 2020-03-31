namespace FitnessApp.Models
{
    public class LogInCredentials
    {
        public string Mail { get; set; }
        public string Password { get; set; }

        public LogInCredentials(string mail, string password)
        {
            this.Mail = mail;
            this.Password = password;
        }
    }
}