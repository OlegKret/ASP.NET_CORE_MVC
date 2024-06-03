using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainSchedule.Migrations
{
    /// <inheritdoc />
    public partial class CreateTrainTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Train",
                columns: new[] { "Id", "ArrivalCity", "AvailableSeats", "DepartureCity", "TrainNumber" },
                values: new object[,]
                {
                    { 1, "Одеса", 20, "Харків", "DE1" },
                    { 2, "Одеса", 48, "Київ", "WE5" },
                    { 3, "Рубіжне", 35, "Харків", "R45" },
                    { 4, "Рубіжне", 5, "Київ", "D4" },
                    { 5, "Суми", 48, "Київ", "WE5" },
                    { 6, "Київ", 48, "Лисичанськ", "WE5" },
                    { 7, "Київ", 30, "Львів", "IC123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Train");
        }
    }
}
