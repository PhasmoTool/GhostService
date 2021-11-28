using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Models
{
    public class GhostEvidence
    {
        public long GhostId { get; set; }
        public Ghost Ghost { get; set; }

        public long EvidenceId { get; set; }
        public Evidence Evidence { get; set; }
    }
}
