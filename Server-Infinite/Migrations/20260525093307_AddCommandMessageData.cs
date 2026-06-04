using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerInfinite.Migrations
{
    /// <inheritdoc />
    public partial class AddCommandMessageData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CommandMessageAutoFlag",
                table: "exvs2ob_message_setting",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "exvs2ob_command_message_data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MessageSettingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Mode = table.Column<uint>(type: "INTEGER", nullable: false),
                    StartMessageText = table.Column<string>(type: "TEXT", nullable: false),
                    StartMessageId = table.Column<uint>(type: "INTEGER", nullable: false),
                    UpMessageText = table.Column<string>(type: "TEXT", nullable: false),
                    UpMessageId = table.Column<uint>(type: "INTEGER", nullable: false),
                    DownMessageText = table.Column<string>(type: "TEXT", nullable: false),
                    DownMessageId = table.Column<uint>(type: "INTEGER", nullable: false),
                    LeftMessageText = table.Column<string>(type: "TEXT", nullable: false),
                    LeftMessageId = table.Column<uint>(type: "INTEGER", nullable: false),
                    RightMessageText = table.Column<string>(type: "TEXT", nullable: false),
                    RightMessageId = table.Column<uint>(type: "INTEGER", nullable: false),
                    EndMessageText = table.Column<string>(type: "TEXT", nullable: false),
                    EndMessageId = table.Column<uint>(type: "INTEGER", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exvs2ob_command_message_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exvs2ob_command_message_data_exvs2ob_message_setting_MessageSettingId",
                        column: x => x.MessageSettingId,
                        principalTable: "exvs2ob_message_setting",
                        principalColumn: "MessageSettingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exvs2ob_command_message_data_Id",
                table: "exvs2ob_command_message_data",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_exvs2ob_command_message_data_MessageSettingId",
                table: "exvs2ob_command_message_data",
                column: "MessageSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_exvs2ob_command_message_data_MessageSettingId_Mode",
                table: "exvs2ob_command_message_data",
                columns: new[] { "MessageSettingId", "Mode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exvs2ob_command_message_data");

            migrationBuilder.DropColumn(
                name: "CommandMessageAutoFlag",
                table: "exvs2ob_message_setting");
        }
    }
}
