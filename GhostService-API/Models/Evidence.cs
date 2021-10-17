using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Models
{
    public class Evidence
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public EvidenceType EvidenceType { get; set; }

        public Evidence()
        {

        }

        public Evidence(long id, string name, EvidenceType evidenceType)
        {
            this.Id = id;
            this.Name = name;
            this.EvidenceType = evidenceType;
        }
    }
}
