namespace UseCase1.Models
{
    public class CapitalInfo
    {
        public List<double> Latlng { get; set; }
        public CapitalInfo()
        {
            Latlng = new List<double>();
        }
    }
}
