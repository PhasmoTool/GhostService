using GhostService_API.Converters;
using GhostService_API.Data_Layer.DBContext;
using GhostService_API.Models;
using GhostService_API.Models.RequestModels;
using GhostService_API.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GhostService_API.Data_Layer.Services
{
    public class EvidenceService
    {
        readonly GhostServiceDBContext context;

        public EvidenceService(GhostServiceDBContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<EvidenceResponse>> GetAllEvidences()
        {
            ICollection<Evidence> evidences = await context.Evidence.ToListAsync();

            List<EvidenceResponse> response = new List<EvidenceResponse>();

            foreach(var evidence in evidences)
            {
                response.Add(EvidenceModelConverter.ConvertDatabaseModelToResponseModel(evidence));
            }

            return response;
        }

        public async Task<EvidenceResponse> PostEvidence(EvidenceRequestModel requestModel)
        {
            Evidence databaseModel = EvidenceModelConverter.ConvertRequestModelToDatabaseModel(requestModel);

            context.Add(databaseModel);
            await context.SaveChangesAsync();

            return EvidenceModelConverter.ConvertDatabaseModelToResponseModel(databaseModel);
        }
    }
}
