namespace UseCase1.Models
{
    public class Country
    {
        public CountryName Name { get; set; }
        public List<string> Tld { get; set; }
        public string Cca2 { get; set; }
        public string Ccn3 { get; set; }
        public string Cca3 { get; set; }
        public string Cioc { get; set; }
        public bool Independent { get; set; }
        public string Status { get; set; }
        public bool UnMember { get; set; }
        public Dictionary<string, Currency> Currencies { get; set; }
        public InternationalCallingCodes Idd { get; set; }
        public List<string> Capital { get; set; }
        public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public Dictionary<string, string> Languages { get; set; }
        public Dictionary<string, CountryName> Translations { get; set; }
        public List<double> Latlng { get; set; }
        public bool Landlocked { get; set; }
        public List<string> Borders { get; set; }
        public double Area { get; set; }
        public Dictionary<string, Demonym> Demonyms { get; set; }
        public string Flag { get; set; }
        public Dictionary<string, string> Maps { get; set; }
        public decimal Population { get; set; }
        public Gini Gini { get; set; }
        public string Fifa { get; set; }
        public CarSign Car { get; set; }
        public List<string> Timezones { get; set; }
        public List<string> Continents { get; set; }
        public Dictionary<string, string> Flags { get; set; }
        public Dictionary<string, string> CoatOfArms { get; set; }
        public string StartOfWeek { get; set; }
        public CapitalInfo CapitalInfo { get; set; }
        public PostalCode PostalCode { get; set; }

        public Country()
        {
            Tld = new List<string>();
            Currencies = new Dictionary<string, Currency>();
            Capital = new List<string>();
            AltSpellings = new List<string>();
            Languages = new Dictionary<string, string>();
            Translations = new Dictionary<string, CountryName>();
            Latlng = new List<double>();
            Borders = new List<string>();
            Demonyms = new Dictionary<string, Demonym>();
            Maps = new Dictionary<string, string>();
            Timezones = new List<string>();
            Continents = new List<string>();
            Flags = new Dictionary<string, string>();
            CoatOfArms = new Dictionary<string, string>();
        }
    }
}
