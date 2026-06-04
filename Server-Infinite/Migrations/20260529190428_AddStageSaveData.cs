using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerInfinite.Migrations
{
    /// <inheritdoc />
    public partial class AddStageSaveData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exvs2ob_stage_save_data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    PatternId = table.Column<uint>(type: "INTEGER", nullable: false),
                    Difficulty = table.Column<uint>(type: "INTEGER", nullable: false),
                    StageNum = table.Column<uint>(type: "INTEGER", nullable: false),
                    BossId1 = table.Column<uint>(type: "INTEGER", nullable: false),
                    BossId2 = table.Column<uint>(type: "INTEGER", nullable: true),
                    MaxGauge = table.Column<uint>(type: "INTEGER", nullable: false),
                    CurrentGauge = table.Column<uint>(type: "INTEGER", nullable: false),
                    MstMobileSuitId = table.Column<uint>(type: "INTEGER", nullable: false),
                    CustomChipIds = table.Column<string>(type: "TEXT", nullable: false),
                    SaveDataUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exvs2ob_stage_save_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exvs2ob_stage_save_data_exvs2ob_card_profile_CardId",
                        column: x => x.CardId,
                        principalTable: "exvs2ob_card_profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exvs2ob_stage_save_data_CardId",
                table: "exvs2ob_stage_save_data",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exvs2ob_stage_save_data_Id",
                table: "exvs2ob_stage_save_data",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exvs2ob_stage_save_data");
        }
    }
}
