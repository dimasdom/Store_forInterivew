using Microsoft.AspNetCore.Identity;


namespace Store.Models.User
{
    public class UserModel : IdentityUser
    {
        public string First_name { get; set; }
        public string Second_name { get; set; }
        public string Cart { get; set; }
        public string Address { get; set; }

    }
}
