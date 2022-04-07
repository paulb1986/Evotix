namespace EvotixEnvironmentalAssessment.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public static User TestUser = new User
        {
            username = "PaulB",
            password = "Evo@85",
            firstname = "Paul",
            lastname = "Beggan"
        };
    }
}
