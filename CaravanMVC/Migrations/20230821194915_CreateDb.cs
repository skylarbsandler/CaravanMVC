using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaravanMVC.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wagons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    num_wheels = table.Column<int>(type: "integer", nullable: false),
                    covered = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wagons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    destination = table.Column<string>(type: "text", nullable: false),
                    wagon_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_passengers", x => x.id);
                    table.ForeignKey(
                        name: "fk_passengers_wagons_wagon_id",
                        column: x => x.wagon_id,
                        principalTable: "wagons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "wagons",
                columns: new[] { "id", "covered", "name", "num_wheels" },
                values: new object[,]
                {
                    { 1, false, "Old Faithful", 4 },
                    { 2, true, "Prairie Pioneer", 6 },
                    { 3, true, "Westward Wanderer", 8 }
                });

            migrationBuilder.InsertData(
                table: "passengers",
                columns: new[] { "id", "age", "destination", "name", "wagon_id" },
                values: new object[,]
                {
                    { 1, 26, "Denver", "Skylar", 1 },
                    { 2, 34, "Denver", "Scott", 1 },
                    { 3, 18, "San Francisco", "Kaila", 2 },
                    { 4, 45, "San Francisco", "Gabe", 2 },
                    { 5, 60, "Portland", "Meghan", 3 },
                    { 6, 39, "Portland", "Griffin", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_passengers_wagon_id",
                table: "passengers",
                column: "wagon_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "wagons");
        }
    }
}
