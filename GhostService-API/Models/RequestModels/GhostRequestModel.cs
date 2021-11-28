using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Models.RequestModels
{
    public class GhostRequestModel
    {
        public string Name { get; set; }
        public List<long> EvidenceIds { get; set; }
    }
}
