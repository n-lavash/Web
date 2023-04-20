using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.BLL.Interfaces;
using TaskTracker.Entity;
using TaskTracker.WebApiPL.Models;

namespace TaskTracker.WebApiPL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        private ITaskTrackerLogic _taskTrackerLogic;

        public HomeController(ILogger<HomeController> logger, ITaskTrackerLogic taskTrackerLogic)
        {
            _logger = logger;
            _taskTrackerLogic = taskTrackerLogic;
        }

        [HttpPost("AddNewTask")]
        public bool AddTask(int idUser, string title, string descriptionInfo, DateTime creationDate, DateTime deadline)
        {
            return _taskTrackerLogic.AddTask(idUser, title, descriptionInfo, creationDate, deadline);
        }

        [HttpPost("AddNewUser")]
        public bool AddUser(string name, string login, string password, string phoneNumber)
        {
            return _taskTrackerLogic.AddUser(name, login, password, phoneNumber);
        }

        [HttpGet("CheckAccount")]
        public bool CheckAccount(string login, string password)
        {
            return _taskTrackerLogic.CheckAccount(login, password);
        }

        [HttpDelete("DeleteTask")]
        public bool DeleteTask(int id)
        {
            return _taskTrackerLogic.DeleteTask(id);
        }

        [HttpPost("EditTask")]
        public bool EditTask(int id, string title, string description, DateTime creationDate, DateTime deadline)
        {
            var task = new UserTask(id, title, description, creationDate, deadline);
            return _taskTrackerLogic.EditTask(task);
        }

        [HttpPost("EditAccount")]
        public bool EditAccount(int id, string login, string password)
        {
            var account = new Account(id, login, password);
            return _taskTrackerLogic.EditAccount(account);
        }

        [HttpPost("EditUser")]
        public bool EditUser(int id, string name, string phoneNumber)
        {
            var user = new User(id, name, phoneNumber);
            return _taskTrackerLogic.EditUser(user);
        }

        [HttpGet("GetTask")]
        public UserTaskModel GetTask(int id)
        {
            var task = _taskTrackerLogic.GetTask(id);
            return UserTaskModel.TaskFromEntity(task);
        }

        [HttpGet("GetUser")]
        public UserModel GetUser(int id)
        {
            var user = _taskTrackerLogic.GetUser(id);
            return UserModel.UserFromEntity(user);
        }

        [HttpGet("GetAccount")]
        public AccountModel GetAccount(int id)
        {
            var account = _taskTrackerLogic.GetAccount(id);
            return AccountModel.AccountFromEntity(account);
        }

        [HttpGet("GetUsersTaskByUserId")]
        public IEnumerable<UserTaskModel> GetUsersTask(int userId)
        {
            var usersTask = _taskTrackerLogic.GetUsersTasks(userId);
            return usersTask.Select(UserTaskModel.TaskFromEntity);
        }
    }
}
