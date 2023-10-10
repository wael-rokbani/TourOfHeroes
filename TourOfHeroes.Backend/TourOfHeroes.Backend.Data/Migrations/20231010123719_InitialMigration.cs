using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourOfHeroes.Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sHero");

            migrationBuilder.CreateTable(
                name: "HeroType",
                schema: "sHero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                schema: "sHero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hero_HeroType_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "sHero",
                        principalTable: "HeroType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hero_TypeId",
                schema: "sHero",
                table: "Hero",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero",
                schema: "sHero");

            migrationBuilder.DropTable(
                name: "HeroType",
                schema: "sHero");
        }
    }
}
