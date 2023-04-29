using TaskTracker.WebApiPL.Models;

namespace TaskTracker.PL.Models
{
    public class UserAccountModel
    {
        public UserModel User { get; set; }
        public AccountModel Account { get; set; }
    }
}
