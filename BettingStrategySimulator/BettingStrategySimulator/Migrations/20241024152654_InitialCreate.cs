using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BettingStrategySimulator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrategyDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrategyConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StrategyDefinitionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategyConfigurations_StrategyDefinitions_StrategyDefinitionId",
                        column: x => x.StrategyDefinitionId,
                        principalTable: "StrategyDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrategyStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfGameSession = table.Column<int>(type: "INTEGER", nullable: false),
                    StrategyDefinitionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategyStatistics_StrategyDefinitions_StrategyDefinitionId",
                        column: x => x.StrategyDefinitionId,
                        principalTable: "StrategyDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StrategyStatisticsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSessions_StrategyStatistics_StrategyStatisticsId",
                        column: x => x.StrategyStatisticsId,
                        principalTable: "StrategyStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BetResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameSessionId = table.Column<long>(type: "INTEGER", nullable: false),
                    StrategyStatisticsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameReult = table.Column<int>(type: "INTEGER", nullable: false),
                    PnL = table.Column<decimal>(type: "TEXT", nullable: false),
                    PreviousBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "TEXT", nullable: false),
                    IncrementId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetResults", x => new { x.Id, x.GameSessionId, x.StrategyStatisticsId });
                    table.ForeignKey(
                        name: "FK_BetResults_GameSessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BetResults_StrategyStatistics_StrategyStatisticsId",
                        column: x => x.StrategyStatisticsId,
                        principalTable: "StrategyStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetResults_GameSessionId",
                table: "BetResults",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_BetResults_StrategyStatisticsId",
                table: "BetResults",
                column: "StrategyStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_StrategyStatisticsId",
                table: "GameSessions",
                column: "StrategyStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyConfigurations_StrategyDefinitionId",
                table: "StrategyConfigurations",
                column: "StrategyDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategyStatistics_StrategyDefinitionId",
                table: "StrategyStatistics",
                column: "StrategyDefinitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetResults");

            migrationBuilder.DropTable(
                name: "StrategyConfigurations");

            migrationBuilder.DropTable(
                name: "GameSessions");

            migrationBuilder.DropTable(
                name: "StrategyStatistics");

            migrationBuilder.DropTable(
                name: "StrategyDefinitions");
        }
    }
}
