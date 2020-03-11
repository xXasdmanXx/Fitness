namespace FitnessApp.Models
{
    using System;
    using System.Text;

    public class Exercise
    {
        public int ID { get; set; }
        public int Person_ID { get; set; }
        public int Mets_ID { get; set; }
        public DateTime Date { get; set; }

        public Exercise(int id, int personID, int metsID, DateTime date)
        {
            this.ID = id;
            this.Person_ID = personID;
            this.Mets_ID = metsID;
            this.Date = date;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder("\nID: ");
            b.Append(this.ID);
            b.Append("\tPerson_ID: "); b.Append(this.Person_ID);
            b.Append("\tMets_ID: "); b.Append(this.Mets_ID);
            b.Append("\tDate: "); b.Append(this.Date);
            b.Append('\n');
            return b.ToString();
        }
    }
}