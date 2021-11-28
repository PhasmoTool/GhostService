using System;
using System.Collections.Generic;
using System.Text;
using GhostService_API.Models;
using GhostService_API.Models.ResponseModels;

namespace GhostService_API.Converters
{
    public static class GhostModelConverter
    {
        static GhostModelConverter()
        {

        }

        public static GhostResponse ConvertDatabaseModeltoResponseModel(Ghost databaseModel, List<Evidence> evidenceDatabaseModels)
        {
            GhostResponse responseModel = new GhostResponse();

            responseModel.Name = databaseModel.Name;
            responseModel.Id = databaseModel.Id;

            List<EvidenceResponse> evidences = new List<EvidenceResponse>();
            foreach(Evidence item in evidenceDatabaseModels)
            {
                evidences.Add(EvidenceModelConverter.ConvertDatabaseModeltoResponseModel(item));
            };

            responseModel.Evidences = evidences;

            return responseModel;
        }
    }
}
