namespace FitnessApp.Models
{
    using System;

    public class Daily
    {
        // Person id
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public Daily(int id, DateTime date)
        {
            this.ID = id;
            this.Date = date;
        }

        public override string ToString()
        {
            return string.Format("\nID: {0}\tDate: {1}\n", this.ID, this.Date);
        }
    }
}