using GhostService_API.Models;
using GhostService_API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Converters
{
    public static class EvidenceModelConverter
    {
        static EvidenceModelConverter()
        {

        }

        public static EvidenceResponse ConvertDatabaseModeltoResponseModel(Evidence databaseModel)
        {
            EvidenceResponse responseModel = new EvidenceResponse();

            responseModel.Id = databaseModel.Id;
            responseModel.evidenceType = databaseModel.EvidenceType;
            responseModel.Name = databaseModel.Name;

            return responseModel;
        }
    }
}
