namespace UserAPI.Models
{
    // This class is for Http post request i.e. to add users in DB
    public class AddUserRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
    }
}
