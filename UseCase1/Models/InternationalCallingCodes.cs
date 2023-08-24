namespace UseCase1.Models
{
    public class InternationalCallingCodes
    {
        public string Root { get; set; }
        public List<string> Suffixes { get; set; }
        public InternationalCallingCodes()
        {
            Suffixes = new List<string>();
        }
    }
}
