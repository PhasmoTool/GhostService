using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GhostService_API.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace GhostService_API.Data_Layer.DBContext
{
    public class GhostServiceContextFactory : IDesignTimeDbContextFactory<GhostServiceDBContext>
    {
        public GhostServiceDBContext CreateDbContext(string[] args)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
            var optionsBuilder = new DbContextOptionsBuilder<GhostServiceDBContext>();
            optionsBuilder.UseSqlServer(SqlConnection);

            return new GhostServiceDBContext(optionsBuilder.Options);
        }
    }

    public class GhostServiceDBContext : DbContext
    {
        public DbSet<Ghost> Ghost { get; set; }
        public DbSet<Evidence> Evidence { get; set; }
        public DbSet<GhostEvidence> GhostEvidence { get; set; }

        public GhostServiceDBContext(DbContextOptions<GhostServiceDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GhostEvidence>().HasKey(i => new { i.EvidenceId, i.GhostId });
        }
    }
}
