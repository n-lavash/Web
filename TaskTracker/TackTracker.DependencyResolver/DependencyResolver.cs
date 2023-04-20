
using Microsoft.Extensions.Configuration;
using TaskTracker.BLL;
using TaskTracker.BLL.Interfaces;
using TaskTracker.DAL;
using TaskTracker.DAL.Interfaces;

namespace TackTracker.Dependencies
{
    public class DependencyResolver
    {
        //private static DependencyResolver _instance;
        //public static DependencyResolver Instance => 
        //    _instance ?? (_instance = new DependencyResolver());

        //public ITaskTrackerDAO TaskTrackerDAO(IServiceProvider serviceProvider) =>
        //    new TaskTrackerDAO(connectionString: serviceProvider.GetService<IConfiguration>().GetConnectionString("MyConnectionString"));

        //public ITaskTrackerLogic TaskTrackerBLL =>
        //    new TaskTrackerLogic(TaskTrackerDAO);
    }
}
