using GhostService_API.Data_Layer.Repos;
using GhostService_API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Data_Layer.Services
{
    public class GhostService
    {
        IGhostRepo repo;

        public GhostService(IGhostRepo repository)
        {
            repo = repository;
        }

        public ICollection<Ghost> GetAllGhosts()
        {
            return repo.GetGhosts();
        }
    }
}
