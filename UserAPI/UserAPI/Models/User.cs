namespace UserAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
    }
}
