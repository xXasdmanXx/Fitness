namespace FitnessApp.Models
{
    using System.Text;

    public class Mets
    {
        public int ID { get; set; }
        public double MET { get; set; }
        public string Major { get; set; }
        public string Detailed { get; set; }

        public Mets(int id, double met, string major, string detailed)
        {
            this.ID = id;
            this.MET = met;
            this.Major = major;
            this.Detailed = detailed;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder("\nID: ");
            b.Append(this.ID);
            b.Append("\tMET: "); b.Append(this.MET);
            b.Append("\tMajor: "); b.Append(this.Major);
            b.Append("\tDetailed: "); b.Append(this.Detailed);
            b.Append('\n');
            return b.ToString();
        }
    }
}