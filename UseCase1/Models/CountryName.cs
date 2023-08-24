namespace UseCase1.Models
{
    public class CountryName
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public Dictionary<string, CountryName> NativeName { get; set; }
    }
}
