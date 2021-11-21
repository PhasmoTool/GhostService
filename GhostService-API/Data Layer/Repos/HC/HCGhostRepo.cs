using GhostService_API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhostService_API.Data_Layer.Repos.HC
{
    public class HCGhostRepo : IGhostRepo
    {
        List<Ghost> ghostTypes;

        public HCGhostRepo()
        {
            // primary evidence types
            Evidence fingerprints = new Evidence(1, "fingerprints", EvidenceType.primary);
            Evidence orbs = new Evidence(2, "ghost orbs", EvidenceType.primary);
            Evidence emf5 = new Evidence(3, "EMF level 5", EvidenceType.primary);
            Evidence spiritBox = new Evidence(4, "spirit box", EvidenceType.primary);
            Evidence freezing = new Evidence(5, "freezing temperatures", EvidenceType.primary);
            Evidence writing = new Evidence(6, "ghost writing", EvidenceType.primary);
            Evidence dots = new Evidence(7, "D.O.T.S. projector", EvidenceType.primary);

            // Hard-coded list for testing

            ghostTypes = new List<Ghost>()
            {
                //new Ghost(1, "Banshee", new List<Evidence> {orbs, fingerprints, dots}),
                //new Ghost(2, "Demon", new List<Evidence> {freezing, fingerprints, writing}),
                //new Ghost(3, "Goryo", new List<Evidence> {emf5, fingerprints, dots}),
                //new Ghost(4, "Hantu", new List<Evidence> {orbs, freezing, fingerprints}),
                //new Ghost(5, "Jinn", new List<Evidence> {emf5, freezing, fingerprints}),
                //new Ghost(6, "Mare", new List<Evidence> {orbs, spiritBox, writing}),
                //new Ghost(7, "Myling", new List<Evidence> {emf5, fingerprints, writing}),
                //new Ghost(8, "Oni", new List<Evidence> {emf5, freezing, dots}),
                //new Ghost(9, "Phantom", new List<Evidence> {spiritBox, fingerprints, dots}),
                //new Ghost(10, "Poltergeist", new List<Evidence> {spiritBox, fingerprints, writing}),
                //new Ghost(11, "Revenant", new List<Evidence> {orbs, freezing, writing}),
                //new Ghost(12, "Shade", new List<Evidence> {emf5, freezing, writing}),
                //new Ghost(13, "Spirit", new List<Evidence> {emf5, spiritBox, writing}),
                //new Ghost(14, "Wraith", new List<Evidence> {emf5, spiritBox, dots}),
                //new Ghost(15, "Yokai", new List<Evidence> {orbs, spiritBox, dots}),
                //new Ghost(16, "Yurei", new List<Evidence> {orbs, freezing, dots})
            };
        }

        public ICollection<Ghost> GetGhosts()
        {
            return ghostTypes;
        }
    }
}
