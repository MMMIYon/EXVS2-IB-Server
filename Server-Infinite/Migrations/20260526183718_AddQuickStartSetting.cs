using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerInfinite.Migrations
{
    /// <inheritdoc />
    public partial class AddQuickStartSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exvs2ob_quick_start_setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuickStartFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    GameMode = table.Column<uint>(type: "INTEGER", nullable: false),
                    RuleType = table.Column<uint>(type: "INTEGER", nullable: true),
                    TeamType = table.Column<uint>(type: "INTEGER", nullable: false),
                    MstMobileSuitId0 = table.Column<uint>(type: "INTEGER", nullable: false),
                    BurstType0 = table.Column<uint>(type: "INTEGER", nullable: false),
                    MstMobileSuitId1 = table.Column<uint>(type: "INTEGER", nullable: false),
                    BurstType1 = table.Column<uint>(type: "INTEGER", nullable: false),
                    StageId = table.Column<uint>(type: "INTEGER", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exvs2ob_quick_start_setting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exvs2ob_quick_start_setting_exvs2ob_card_profile_CardId",
                        column: x => x.CardId,
                        principalTable: "exvs2ob_card_profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exvs2ob_quick_start_setting_CardId",
                table: "exvs2ob_quick_start_setting",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exvs2ob_quick_start_setting_Id",
                table: "exvs2ob_quick_start_setting",
                column: "Id");

            migrationBuilder.Sql(
                """
                INSERT INTO exvs2ob_quick_start_setting (
                    CardId, QuickStartFlag, GameMode, TeamType,
                    MstMobileSuitId0, BurstType0, MstMobileSuitId1, BurstType1, StageId,
                    CreateTime, UpdateTime)
                SELECT
                    Id, 0, 0, 0,
                    0, 0, 0, 0, 0,
                    datetime('now'), datetime('now')
                FROM exvs2ob_card_profile;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exvs2ob_quick_start_setting");
        }
    }
}
