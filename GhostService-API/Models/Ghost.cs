using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GhostService_API.Models
{
    public class Ghost
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<GhostEvidence> Evidence { get; set; }

        public Ghost()
        {
            Evidence = new HashSet<GhostEvidence>();
        }

        public Ghost(long id, string name, ICollection<GhostEvidence> evidence)
        {
            this.Id = id;
            this.Name = name;
            this.Evidence = evidence;
        }
    }
}
