using DataApi.Core.IRepository;
using DataApi.Core.IService;
using DataApi.Repository.DataRepository;
using DataApi.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataApi.Services.Service.Services;

namespace DataApi.Utility
{
    public class DIResolvers
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //for accessing the http context by interface in view level
            #region Http context
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            //for service accesssing
            #region Service
            services.AddScoped<IDataService, DataServices>();
            #endregion
            //for database accessing
            #region Repository
            services.AddScoped<IDataRepository, DataRepository>();
            #endregion
        }
    }
}
