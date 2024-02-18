using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicDashboardSample.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    StageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "Vysor",
                columns: table => new
                {
                    VysorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vysor", x => x.VysorId);
                });

            migrationBuilder.CreateTable(
                name: "VysorStage",
                columns: table => new
                {
                    VysorId = table.Column<int>(type: "INTEGER", nullable: false),
                    StageId = table.Column<int>(type: "INTEGER", nullable: false),
                    PosX = table.Column<int>(type: "INTEGER", nullable: false),
                    PosY = table.Column<int>(type: "INTEGER", nullable: false),
                    SizeW = table.Column<int>(type: "INTEGER", nullable: false),
                    SizeH = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VysorStage", x => new { x.VysorId, x.StageId });
                    table.ForeignKey(
                        name: "FK_VysorStage_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VysorStage_Vysor_VysorId",
                        column: x => x.VysorId,
                        principalTable: "Vysor",
                        principalColumn: "VysorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VysorStage_StageId",
                table: "VysorStage",
                column: "StageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VysorStage");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "Vysor");
        }
    }
}
