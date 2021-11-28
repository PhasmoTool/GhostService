using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GhostService_API.Models
{
    public class Evidence
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public EvidenceType EvidenceType { get; set; }
        public ICollection<GhostEvidence> Ghosts { get; set; }

        public Evidence()
        {
            this.Ghosts = new HashSet<GhostEvidence>();
        }

        public Evidence(long id, string name, EvidenceType evidenceType)
        {
            this.Id = id;
            this.Name = name;
            this.EvidenceType = evidenceType;
        }
    }
}
