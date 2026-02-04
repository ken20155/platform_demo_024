using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlatformDemo.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicePlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicePlanId = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_ServicePlans_ServicePlanId",
                        column: x => x.ServicePlanId,
                        principalTable: "ServicePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ServicePlans",
                columns: new[] { "Id", "DateOfPurchase" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 1, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(277) },
                    { 2, new DateTime(2026, 1, 29, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(305) },
                    { 3, new DateTime(2026, 1, 26, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(306) },
                    { 4, new DateTime(2026, 1, 23, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(308) },
                    { 5, new DateTime(2026, 1, 20, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(309) },
                    { 6, new DateTime(2026, 1, 17, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(312) },
                    { 7, new DateTime(2026, 1, 14, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(313) },
                    { 8, new DateTime(2026, 1, 11, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(314) },
                    { 9, new DateTime(2026, 1, 8, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(315) },
                    { 10, new DateTime(2026, 1, 5, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(317) },
                    { 11, new DateTime(2026, 1, 2, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(317) },
                    { 12, new DateTime(2025, 12, 30, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(318) }
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "Id", "Description", "EndDateTime", "ServicePlanId", "StartDateTime" },
                values: new object[,]
                {
                    { 1, "Seeded work log - Ken - 1", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(479), 1, new DateTime(2026, 2, 3, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(476) },
                    { 2, "Seeded work log - Ken - 1", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(495), 1, new DateTime(2026, 2, 2, 21, 45, 48, 693, DateTimeKind.Local).AddTicks(494) },
                    { 3, "Seeded work log - Ken - 1", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(497), 1, new DateTime(2026, 2, 3, 1, 45, 48, 693, DateTimeKind.Local).AddTicks(497) },
                    { 4, "Seeded work log - Ken - 2", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(499), 2, new DateTime(2026, 2, 3, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(499) },
                    { 5, "Seeded work log - Ken - 2", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(502), 2, new DateTime(2026, 2, 4, 8, 45, 48, 693, DateTimeKind.Local).AddTicks(501) },
                    { 6, "Seeded work log - Ken - 2", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(504), 2, new DateTime(2026, 2, 3, 5, 45, 48, 693, DateTimeKind.Local).AddTicks(503) },
                    { 7, "Seeded work log - Ken - 2", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(505), 2, new DateTime(2026, 2, 2, 20, 45, 48, 693, DateTimeKind.Local).AddTicks(505) },
                    { 8, "Seeded work log - Ken - 3", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(538), 3, new DateTime(2026, 2, 2, 21, 45, 48, 693, DateTimeKind.Local).AddTicks(538) },
                    { 9, "Seeded work log - Ken - 3", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(541), 3, new DateTime(2026, 2, 3, 13, 45, 48, 693, DateTimeKind.Local).AddTicks(540) },
                    { 10, "Seeded work log - Ken - 3", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(544), 3, new DateTime(2026, 2, 4, 1, 45, 48, 693, DateTimeKind.Local).AddTicks(543) },
                    { 11, "Seeded work log - Ken - 3", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(545), 3, new DateTime(2026, 2, 4, 11, 45, 48, 693, DateTimeKind.Local).AddTicks(545) },
                    { 12, "Seeded work log - Ken - 4", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(547), 4, new DateTime(2026, 2, 3, 9, 45, 48, 693, DateTimeKind.Local).AddTicks(546) },
                    { 13, "Seeded work log - Ken - 4", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(549), 4, new DateTime(2026, 2, 2, 21, 45, 48, 693, DateTimeKind.Local).AddTicks(549) },
                    { 14, "Seeded work log - Ken - 4", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(551), 4, new DateTime(2026, 2, 3, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(551) },
                    { 15, "Seeded work log - Ken - 4", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(553), 4, new DateTime(2026, 2, 4, 2, 45, 48, 693, DateTimeKind.Local).AddTicks(552) },
                    { 16, "Seeded work log - Ken - 5", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(555), 5, new DateTime(2026, 2, 3, 7, 45, 48, 693, DateTimeKind.Local).AddTicks(554) },
                    { 17, "Seeded work log - Ken - 7", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(559), 7, new DateTime(2026, 2, 3, 6, 45, 48, 693, DateTimeKind.Local).AddTicks(558) },
                    { 18, "Seeded work log - Ken - 7", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(563), 7, new DateTime(2026, 2, 3, 17, 45, 48, 693, DateTimeKind.Local).AddTicks(562) },
                    { 19, "Seeded work log - Ken - 7", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(564), 7, new DateTime(2026, 2, 2, 17, 45, 48, 693, DateTimeKind.Local).AddTicks(563) },
                    { 20, "Seeded work log - Ken - 8", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(566), 8, new DateTime(2026, 2, 4, 4, 45, 48, 693, DateTimeKind.Local).AddTicks(565) },
                    { 21, "Seeded work log - Ken - 8", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(569), 8, new DateTime(2026, 2, 3, 19, 45, 48, 693, DateTimeKind.Local).AddTicks(568) },
                    { 22, "Seeded work log - Ken - 8", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(570), 8, new DateTime(2026, 2, 2, 17, 45, 48, 693, DateTimeKind.Local).AddTicks(569) },
                    { 23, "Seeded work log - Ken - 8", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(572), 8, new DateTime(2026, 2, 2, 17, 45, 48, 693, DateTimeKind.Local).AddTicks(571) },
                    { 24, "Seeded work log - Ken - 8", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(573), 8, new DateTime(2026, 2, 4, 8, 45, 48, 693, DateTimeKind.Local).AddTicks(573) },
                    { 25, "Seeded work log - Ken - 9", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(575), 9, new DateTime(2026, 2, 2, 18, 45, 48, 693, DateTimeKind.Local).AddTicks(574) },
                    { 26, "Seeded work log - Ken - 9", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(577), 9, new DateTime(2026, 2, 4, 5, 45, 48, 693, DateTimeKind.Local).AddTicks(577) },
                    { 27, "Seeded work log - Ken - 9", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(579), 9, new DateTime(2026, 2, 4, 11, 45, 48, 693, DateTimeKind.Local).AddTicks(578) },
                    { 28, "Seeded work log - Ken - 11", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(581), 11, new DateTime(2026, 2, 2, 15, 45, 48, 693, DateTimeKind.Local).AddTicks(580) },
                    { 29, "Seeded work log - Ken - 11", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(586), 11, new DateTime(2026, 2, 4, 10, 45, 48, 693, DateTimeKind.Local).AddTicks(585) },
                    { 30, "Seeded work log - Ken - 11", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(587), 11, new DateTime(2026, 2, 3, 8, 45, 48, 693, DateTimeKind.Local).AddTicks(587) },
                    { 31, "Seeded work log - Ken - 11", new DateTime(2026, 2, 4, 14, 45, 48, 693, DateTimeKind.Local).AddTicks(589), 11, new DateTime(2026, 2, 3, 23, 45, 48, 693, DateTimeKind.Local).AddTicks(588) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_ServicePlanId",
                table: "Timesheets",
                column: "ServicePlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropTable(
                name: "ServicePlans");
        }
    }
}
