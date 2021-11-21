﻿using GhostService_API;
using GhostService_API.Data_Layer.Repos;
using GhostService_API.Data_Layer.Repos.DBContext;
using GhostService_API.Data_Layer.Repos.HC;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]

namespace GhostService_API
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IGhostRepo, HCGhostRepo>();

            string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<GhostServiceDBContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, SqlConnection));
        }
    }
}
