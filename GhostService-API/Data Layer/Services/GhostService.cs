using GhostService_API.Models.ResponseModels;
using GhostService_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GhostService_API.Converters;
using GhostService_API.Data_Layer.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GhostService_API.Models.RequestModels;

namespace GhostService_API.Data_Layer.Services
{
    public class GhostService
    {
        readonly GhostServiceDBContext context;

        public GhostService(GhostServiceDBContext context)
        {
            this.context = context;
        }

        public async Task<GhostResponse> PostGhost(GhostRequestModel requestModel)
        {
            Ghost databaseModel = GhostModelConverter.ConvertRequestModelToDatabaseModel(requestModel);

            context.Ghost.Add(databaseModel);
            await context.SaveChangesAsync();

            List<Evidence> evidences = new List<Evidence>();
            foreach (var item in databaseModel.Evidence)
            {
                Evidence evid = await context.Evidence.FindAsync(item.EvidenceId);
                evidences.Add(evid);
            }

            return GhostModelConverter.ConvertDatabaseModelToResponseModel(databaseModel, evidences);
        }

        public async Task<ICollection<GhostResponse>> GetAllGhosts()
        {
            ICollection<Ghost> ghosts = await context.Ghost.Include(ghost => ghost.Evidence).ToListAsync();

            List<GhostResponse> responseModels = new List<GhostResponse>();

            foreach(Ghost ghost in ghosts)
            {
                List<Evidence> evidences = new List<Evidence>();
                foreach(var item in ghost.Evidence)
                {
                    Evidence evid = await context.Evidence.FindAsync(item.EvidenceId);
                    evidences.Add(evid);
                }

                responseModels.Add(GhostModelConverter.ConvertDatabaseModelToResponseModel(ghost, evidences));
            }

            return responseModels;
        }
    }
}
