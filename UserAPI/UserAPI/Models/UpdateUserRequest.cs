namespace UserAPI.Models
{
    // This class is for put request i.e. to update user details in DB
    public class UpdateUserRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
    }
}
