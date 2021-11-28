using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GhostService_API.Data_Layer.DBContext;
using GhostService_API.Data_Layer.Services;
using GhostService_API.Models.RequestModels;
using GhostService_API.Models.ResponseModels;
using System.Collections.Generic;

namespace GhostService_API.ControllerFunctions
{
    public class EvidenceControllerFunctions
    {
        private EvidenceService service;

        public EvidenceControllerFunctions(GhostServiceDBContext context)
        {
            service = new EvidenceService(context);
        }

        [FunctionName("GetEvidence")]
        public async Task<IActionResult> GetEvidence([HttpTrigger(AuthorizationLevel.Function, "get", Route = "evidence")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ICollection<EvidenceResponse> evidence = await service.GetAllEvidences();

            return new OkObjectResult(evidence);
        }

        [FunctionName("AddEvidence")]
        public async Task<IActionResult> PostEvidence([HttpTrigger(AuthorizationLevel.Function, "post", Route = "evidence")] HttpRequest req)
        {
            string body = await new StreamReader(req.Body).ReadToEndAsync();
            EvidenceRequestModel reqModel = JsonConvert.DeserializeObject<EvidenceRequestModel>(body);
            EvidenceResponse response = await service.PostEvidence(reqModel);

            return new CreatedResult("GetEvidence", response);
        }
    }
}
