using Microsoft.EntityFrameworkCore.Migrations;

namespace GhostService_API.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ghostEvidence_evidence_EvidenceId",
                table: "ghostEvidence");

            migrationBuilder.DropForeignKey(
                name: "FK_ghostEvidence_ghosts_GhostId",
                table: "ghostEvidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ghostEvidence",
                table: "ghostEvidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_evidence",
                table: "evidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ghosts",
                table: "ghosts");

            migrationBuilder.RenameTable(
                name: "ghostEvidence",
                newName: "GhostEvidence");

            migrationBuilder.RenameTable(
                name: "evidence",
                newName: "Evidence");

            migrationBuilder.RenameTable(
                name: "ghosts",
                newName: "Ghost");

            migrationBuilder.RenameIndex(
                name: "IX_ghostEvidence_GhostId",
                table: "GhostEvidence",
                newName: "IX_GhostEvidence_GhostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GhostEvidence",
                table: "GhostEvidence",
                columns: new[] { "EvidenceId", "GhostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evidence",
                table: "Evidence",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ghost",
                table: "Ghost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GhostEvidence_Evidence_EvidenceId",
                table: "GhostEvidence",
                column: "EvidenceId",
                principalTable: "Evidence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GhostEvidence_Ghost_GhostId",
                table: "GhostEvidence",
                column: "GhostId",
                principalTable: "Ghost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GhostEvidence_Evidence_EvidenceId",
                table: "GhostEvidence");

            migrationBuilder.DropForeignKey(
                name: "FK_GhostEvidence_Ghost_GhostId",
                table: "GhostEvidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GhostEvidence",
                table: "GhostEvidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evidence",
                table: "Evidence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ghost",
                table: "Ghost");

            migrationBuilder.RenameTable(
                name: "GhostEvidence",
                newName: "ghostEvidence");

            migrationBuilder.RenameTable(
                name: "Evidence",
                newName: "evidence");

            migrationBuilder.RenameTable(
                name: "Ghost",
                newName: "ghosts");

            migrationBuilder.RenameIndex(
                name: "IX_GhostEvidence_GhostId",
                table: "ghostEvidence",
                newName: "IX_ghostEvidence_GhostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ghostEvidence",
                table: "ghostEvidence",
                columns: new[] { "EvidenceId", "GhostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_evidence",
                table: "evidence",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ghosts",
                table: "ghosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ghostEvidence_evidence_EvidenceId",
                table: "ghostEvidence",
                column: "EvidenceId",
                principalTable: "evidence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ghostEvidence_ghosts_GhostId",
                table: "ghostEvidence",
                column: "GhostId",
                principalTable: "ghosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
