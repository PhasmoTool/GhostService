using System;
using System.IO;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GhostService_API.Data_Layer.Repos;
using GhostService_API.Data_Layer.Services;
using GhostService_API.Models;
using System.Collections.Generic;
using GhostService_API.Data_Layer.Repos.DBContext;

namespace GhostService_API.ControllerFunctions
{
    public class GhostControllerFunctions
    {
        private GhostService ghostService;

        private GhostServiceDBContext context;

        public GhostControllerFunctions(IGhostRepo repository, GhostServiceDBContext context)
        {
            ghostService = new GhostService(repository);
            this.context = context;
        }

        [FunctionName("GetGhosts")]
        public async Task<IActionResult> GetAllGhosts([HttpTrigger(AuthorizationLevel.Function, "get", Route = "ghosts")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            List<Ghost> ghosts = ghostService.GetAllGhosts().ToList();

            return new OkObjectResult(ghosts);
        }

        [FunctionName("AddGhost")]
        public async Task<IActionResult> PostGhost([HttpTrigger(AuthorizationLevel.Function, "post", Route = "ghosts")] HttpRequest req)
        {
            return new OkObjectResult(null);
        }
    }
}
