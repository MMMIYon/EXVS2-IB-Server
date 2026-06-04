using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerInfinite.Migrations
{
    /// <inheritdoc />
    public partial class AddMsStickerProtoTestFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CostumeIds",
                table: "exvs2ob_ms_sticker",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CutinImageUseFlag",
                table: "exvs2ob_ms_sticker",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PilotImageDispFlag",
                table: "exvs2ob_ms_sticker",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PoseIds",
                table: "exvs2ob_ms_sticker",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<uint>(
                name: "SubBackgroundId",
                table: "exvs2ob_ms_sticker",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostumeIds",
                table: "exvs2ob_ms_sticker");

            migrationBuilder.DropColumn(
                name: "CutinImageUseFlag",
                table: "exvs2ob_ms_sticker");

            migrationBuilder.DropColumn(
                name: "PilotImageDispFlag",
                table: "exvs2ob_ms_sticker");

            migrationBuilder.DropColumn(
                name: "PoseIds",
                table: "exvs2ob_ms_sticker");

            migrationBuilder.DropColumn(
                name: "SubBackgroundId",
                table: "exvs2ob_ms_sticker");
        }
    }
}
