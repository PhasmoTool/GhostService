using System;
using System.Collections.Generic;
using System.Text;
using GhostService_API.Models;
using GhostService_API.Models.RequestModels;
using GhostService_API.Models.ResponseModels;

namespace GhostService_API.Converters
{
    public static class GhostModelConverter
    {
        static GhostModelConverter()
        {

        }

        public static GhostResponse ConvertDatabaseModelToResponseModel(Ghost databaseModel, List<Evidence> evidenceDatabaseModels)
        {
            GhostResponse responseModel = new GhostResponse
            {
                Name = databaseModel.Name,
                Id = databaseModel.Id
            };

            List<EvidenceResponse> evidences = new List<EvidenceResponse>();
            foreach(Evidence item in evidenceDatabaseModels)
            {
                evidences.Add(EvidenceModelConverter.ConvertDatabaseModelToResponseModel(item));
            };

            responseModel.Evidences = evidences;

            return responseModel;
        }

        public static Ghost ConvertRequestModelToDatabaseModel(GhostRequestModel requestModel)
        {
            Ghost databaseModel = new Ghost()
            {
                Name = requestModel.Name
            };

            List<GhostEvidence> ghostEvidences = new List<GhostEvidence>();
            foreach (long id in requestModel.EvidenceIds)
            {
                ghostEvidences.Add(new GhostEvidence()
                {
                    Ghost = databaseModel,
                    EvidenceId = id
                });
            }

            databaseModel.Evidence = ghostEvidences;

            return databaseModel;
        }
    }
}
