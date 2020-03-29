namespace FitnessApp.Models
{
    public class Search
    {
        public int Top { get; set; }
        public string Query { get; set; }

        public Search(int top, string query)
        {
            this.Top = top;
            this.Query = query;
        }
    }
}