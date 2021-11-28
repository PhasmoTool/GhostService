using GhostService_API.Data_Layer.Repos;
using GhostService_API.Models.ResponseModels;
using GhostService_API.Models;
using GhostService_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GhostService_API.Converters;
using GhostService_API.Data_Layer.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GhostService_API.Data_Layer.Services
{
    public class GhostService
    {
        GhostServiceDBContext context;

        public GhostService(GhostServiceDBContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<GhostResponse>> GetAllGhosts()
        {
            ICollection<Ghost> ghosts = await context.ghosts.ToListAsync();

            List<GhostResponse> responseModels = new List<GhostResponse>();

            foreach(Ghost ghost in ghosts)
            {
                List<Evidence> evidences = new List<Evidence>();
                foreach(var item in ghost.Evidence)
                {
                    evidences.Add(item.Evidence);
                }

                responseModels.Add(GhostModelConverter.ConvertDatabaseModeltoResponseModel(ghost, evidences));
            }

            return responseModels;
        }
    }
}
