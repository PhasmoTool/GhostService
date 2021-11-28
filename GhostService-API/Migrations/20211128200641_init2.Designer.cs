﻿// <auto-generated />
using GhostService_API.Data_Layer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GhostService_API.Migrations
{
    [DbContext(typeof(GhostServiceDBContext))]
    [Migration("20211128200641_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GhostService_API.Models.Evidence", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EvidenceType");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Evidence");
                });

            modelBuilder.Entity("GhostService_API.Models.Ghost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ghost");
                });

            modelBuilder.Entity("GhostService_API.Models.GhostEvidence", b =>
                {
                    b.Property<long>("EvidenceId");

                    b.Property<long>("GhostId");

                    b.HasKey("EvidenceId", "GhostId");

                    b.HasIndex("GhostId");

                    b.ToTable("GhostEvidence");
                });

            modelBuilder.Entity("GhostService_API.Models.GhostEvidence", b =>
                {
                    b.HasOne("GhostService_API.Models.Evidence", "Evidence")
                        .WithMany("Ghosts")
                        .HasForeignKey("EvidenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GhostService_API.Models.Ghost", "Ghost")
                        .WithMany("Evidence")
                        .HasForeignKey("GhostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
