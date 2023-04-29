using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.BLL.Interfaces;

namespace TaskTracker.DependencyResolver
{
    public static class DependencyInjection
    {
        public static void InjectAllDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITaskTrackerLogic, TaskTrackerLogic>();
            services.AddSingleton<ITaskTrackerDAO>(provider => new TaskTrackerDAO(connectionString));
        }
    }
}
