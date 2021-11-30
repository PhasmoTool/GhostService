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
using GhostService_API.Data_Layer.Services;
using GhostService_API.Models;
using System.Collections.Generic;
using GhostService_API.Data_Layer.DBContext;
using GhostService_API.Models.ResponseModels;
using GhostService_API.Models.RequestModels;

namespace GhostService_API.ControllerFunctions
{
    public class GhostControllerFunctions
    {
        private readonly GhostService ghostService;

        public GhostControllerFunctions(GhostServiceDBContext context)
        {
            ghostService = new GhostService(context);
        }

        [FunctionName("GetGhosts")]
        public async Task<IActionResult> GetAllGhosts([HttpTrigger(AuthorizationLevel.Function, "get", Route = "ghosts")] HttpRequest req)
        {
            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ICollection<GhostResponse> ghosts = await ghostService.GetAllGhosts();

            return new OkObjectResult(ghosts);
        }

        [FunctionName("AddGhost")]
        public async Task<IActionResult> PostGhost([HttpTrigger(AuthorizationLevel.Function, "post", Route = "ghosts")] HttpRequest req)
        {
            string body = await new StreamReader(req.Body).ReadToEndAsync();
            GhostRequestModel reqModel = JsonConvert.DeserializeObject<GhostRequestModel>(body);
            GhostResponse response = await ghostService.PostGhost(reqModel);

            return new CreatedResult("GetEvidence", response);
        }
    }
}
