using GhostService_API;
using GhostService_API.Data_Layer.DBContext;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

[assembly: FunctionsStartup(typeof(Startup))]

namespace GhostService_API
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("ConnectionStrings:SqlConnectionString");
            builder.Services.AddDbContext<GhostServiceDBContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, SqlConnection));
        }
    }
}
