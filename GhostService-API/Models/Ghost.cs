using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Models
{
    public class Ghost
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Evidence> Evidence { get; set; }

        public Ghost()
        {
            Evidence = new HashSet<Evidence>();
        }

        public Ghost(long id, string name, ICollection<Evidence> evidence)
        {
            this.Id = id;
            this.Name = name;
            this.Evidence = evidence;
        }
    }
}
