using GhostService_API.Models;
using GhostService_API.Models.RequestModels;
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

        public static EvidenceResponse ConvertDatabaseModelToResponseModel(Evidence databaseModel)
        {
            if(databaseModel != null)
            {
                EvidenceResponse responseModel = new EvidenceResponse
                {
                    Id = databaseModel.Id,
                    EvidenceType = databaseModel.EvidenceType,
                    Name = databaseModel.Name
                };

                return responseModel;
            }
            else
            {
                return null;
            }
        }

        public static Evidence ConvertRequestModelToDatabaseModel(EvidenceRequestModel requestModel)
        {
            Evidence databaseModel = new Evidence()
            {
                Name = requestModel.Name,
                EvidenceType = requestModel.EvidenceType
            };

            return databaseModel;
        }
    }
}
