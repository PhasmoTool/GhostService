using GhostService_API;
using GhostService_API.Data_Layer.Repos;
using GhostService_API.Data_Layer.Repos.HC;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
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
        }
    }
}
