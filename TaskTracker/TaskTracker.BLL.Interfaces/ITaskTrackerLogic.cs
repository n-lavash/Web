using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Entity;

namespace TaskTracker.BLL.Interfaces
{
    public interface ITaskTrackerLogic
    {
        bool AddTask(int idUser, string title, string descriptionInfo, DateTime creationDate, DateTime deadline);
        bool AddUser(string name, string login, string password, string phoneNumber);
        bool CheckAccount(string login, string password);
        bool DeleteTask(int id);
        bool EditTask(UserTask exercise);
        bool EditAccount(Account account);
        bool EditUser(User user);
        UserTask GetTask(int id);
        User GetUser(int id);
        Account GetAccount(int id);
        IEnumerable<UserTask> GetUsersTasks(int idUser);
    }
}
