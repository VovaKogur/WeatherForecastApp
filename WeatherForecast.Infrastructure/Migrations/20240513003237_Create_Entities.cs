using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherForecast.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageTemperature = table.Column<double>(type: "float", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HourlyWeathers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    TemperatureC = table.Column<double>(type: "float", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeatherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyWeathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlyWeathers_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourlyWeathers_WeatherId",
                table: "HourlyWeathers",
                column: "WeatherId");
            migrationBuilder.Sql(@"CREATE PROCEDURE DeleteOldWeatherData
                                   AS
                                   BEGIN
                                       SET NOCOUNT ON;  
                                       DELETE FROM Weather
                                       WHERE CreatedDate < DATEADD(MONTH, -1, GETDATE());
                                   END;
                                   GO
                                   ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourlyWeathers");

            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
