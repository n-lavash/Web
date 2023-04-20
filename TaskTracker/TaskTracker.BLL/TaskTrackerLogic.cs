using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL.Interfaces;
using TaskTracker.Entity;

namespace TaskTracker.BLL
{
    public class TaskTrackerLogic : ITaskTrackerLogic
    {
        private ITaskTrackerDAO _taskTrackerDAO;

        public TaskTrackerLogic(ITaskTrackerDAO taskTrackerDAO)
        {
            _taskTrackerDAO = taskTrackerDAO;
        }

        public bool AddTask(int idUser, string title, string descriptionInfo, DateTime creationDate, DateTime deadline) =>
            _taskTrackerDAO.AddTask(idUser, title, descriptionInfo, creationDate, deadline);

        public bool AddUser(string name, string login, string password, string phoneNumber) =>
            _taskTrackerDAO.AddUser(name, login, password, phoneNumber);

        public bool CheckAccount(string login, string password) =>
            _taskTrackerDAO.CheckAccount(login, password);

        public bool DeleteTask(int id) =>
            _taskTrackerDAO.DeleteTask(id);

        public bool EditTask(UserTask exercise) =>
            _taskTrackerDAO.EditTask(exercise);

        public bool EditAccount(Account account) =>
            _taskTrackerDAO.EditAccount(account);

        public bool EditUser(User user) =>
            _taskTrackerDAO.EditUser(user);

        public UserTask GetTask(int id) =>
            _taskTrackerDAO.GetTask(id);

        public User GetUser(int id) =>
            _taskTrackerDAO.GetUser(id);

        public Account GetAccount(int id) =>
            _taskTrackerDAO.GetAccount(id);

        public IEnumerable<UserTask> GetUsersTasks(int idUser) =>
            _taskTrackerDAO.GetUsersTasks(idUser);
    }
}
