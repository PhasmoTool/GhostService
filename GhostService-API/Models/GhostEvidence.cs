using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Models
{
    public class GhostEvidence
    {
        public long GhostId { get; set; }
        public virtual Ghost Ghost { get; set; }

        public long EvidenceId { get; set; }
        public virtual Evidence Evidence { get; set; }
    }
}
