using TaskTracker.Entity;

namespace TaskTracker.WebApiPL.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public static AccountModel AccountFromEntity(Account account)
        {
            return new AccountModel()
            {
                Id = account.Id,
                Login = account.Login,
                Password = account.Password
            };
        }
    }
}
