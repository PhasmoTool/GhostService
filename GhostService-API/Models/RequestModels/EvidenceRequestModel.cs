using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Models.RequestModels
{
    public class EvidenceRequestModel
    {
        public string Name { get; set; }
        public EvidenceType EvidenceType { get; set; }
    }
}
