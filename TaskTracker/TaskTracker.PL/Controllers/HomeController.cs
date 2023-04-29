using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskTracker.BLL.Interfaces;
using TaskTracker.Entity;
using TaskTracker.PL.Models;
using TaskTracker.WebApiPL.Models;

namespace TaskTracker.PL.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITaskTrackerLogic _taskTrackerLogic;

        public HomeController(ILogger<HomeController> logger, ITaskTrackerLogic taskTrackerLogic)
        {
            _logger = logger;
            _taskTrackerLogic = taskTrackerLogic;
        }

        // Нужно в меню
        public IActionResult GetUsersTask(UserModel user)
        {
            var id = user.Id;
            var usersTask = _taskTrackerLogic.GetUsersTasks(id);
            var userTaskSelected = usersTask.Select(UserTaskModel.TaskFromEntity);
            return View(userTaskSelected);
        }

        public IActionResult AddTask(UserModel user, UserTaskModel task)
        {
            var id = user.Id;
            var title = task.Title;
            var descriptionInfo = task.Description;
            var creationDate = task.CreatedDate;
            var deadline = task.DeadLine;

            _taskTrackerLogic.AddTask(id, title, descriptionInfo, creationDate, deadline);
            return RedirectToAction("GetUsersTask", "Home");
        }

        public IActionResult DeleteTask(UserTaskModel task)
        {
            _taskTrackerLogic.DeleteTask(task.Id);
            return RedirectToAction("GetUsersTask", "Home");
        }

        public IActionResult EditTask(UserModel user, UserTaskModel taskModel)
        {
            var id = user.Id;
            var title = taskModel.Title;
            var description = taskModel.Description;
            var creationDate = taskModel.CreatedDate;
            var deadline = taskModel.DeadLine;

            var task = new UserTask(user.Id, title, description, creationDate, deadline);
            _taskTrackerLogic.EditTask(task);
            return RedirectToAction("GetTask", "Home");
        }

        public IActionResult GetTask(UserTaskModel taskModel)
        {
            var task = _taskTrackerLogic.GetTask(taskModel.Id);
            var taskFromEntity = UserTaskModel.TaskFromEntity(task);
            return View(taskFromEntity);
        }

        // добавить в меню
        public IActionResult GetUserAccount(UserModel userModel)
        {
            var id = userModel.Id;

            var user = _taskTrackerLogic.GetUser(id);
            var userFromEntity = UserModel.UserFromEntity(user);
            var account = _taskTrackerLogic.GetAccount(id);
            var accountFromEntity = AccountModel.AccountFromEntity(account);

            var userAccount = new UserAccountModel
            {
                User = userFromEntity,
                Account = accountFromEntity
            };

            return View(userAccount);
        }

        public IActionResult EditAccount(AccountModel accountModel)
        {
            var id = accountModel.Id;
            var login = accountModel.Login;
            var password = accountModel.Password;

            var account = new Account(id, login, password);
            _taskTrackerLogic.EditAccount(account);
            return RedirectToAction("GetUserAccount", "Home");
        }

        public IActionResult EditUser(UserModel userModel)
        {
            var id = userModel.Id;
            var name = userModel.Name;
            var phoneNumber = userModel.PhoneNumber;

            var user = new User(id, name, phoneNumber);
            _taskTrackerLogic.EditUser(user);
            return RedirectToAction("GetUserAccount", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}