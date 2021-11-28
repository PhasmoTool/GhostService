using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Models.ResponseModels
{
    public class GhostResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<EvidenceResponse> Evidences { get; set; }
    }
}
