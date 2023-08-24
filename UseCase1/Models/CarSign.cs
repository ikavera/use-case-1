namespace UseCase1.Models
{
    public class CarSign
    {
        public string? Side { get; set; }
        public List<string> Signs { get; set; }

        public CarSign()
        {
            Signs = new List<string>();
        }
    }
}
