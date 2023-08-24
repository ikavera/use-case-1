namespace UseCase1.Models
{
    public class Gini
    {
        public Dictionary<string, int> Data { get; set; }

        public Gini()
        {
            Data = new Dictionary<string, int>();
        }
    }
}
