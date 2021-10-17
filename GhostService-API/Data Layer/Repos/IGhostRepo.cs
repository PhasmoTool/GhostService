using GhostService_API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Data_Layer.Repos
{
    public interface IGhostRepo
    {
        ICollection<Ghost> GetGhosts();
    }
}
