using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerInfinite.Migrations
{
    /// <inheritdoc />
    public partial class AddStickerTrackerCustomText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tracker1CustomText",
                table: "exvs2ob_ms_sticker",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tracker2CustomText",
                table: "exvs2ob_ms_sticker",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tracker3CustomText",
                table: "exvs2ob_ms_sticker",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tracker1CustomText",
                table: "exvs2ob_default_sticker_profile",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tracker2CustomText",
                table: "exvs2ob_default_sticker_profile",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tracker3CustomText",
                table: "exvs2ob_default_sticker_profile",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tracker1CustomText",
                table: "exvs2ob_ms_sticker");

            migrationBuilder.DropColumn(
                name: "Tracker2CustomText",
                table: "exvs2ob_ms_sticker");

            migrationBuilder.DropColumn(
                name: "Tracker3CustomText",
                table: "exvs2ob_ms_sticker");

            migrationBuilder.DropColumn(
                name: "Tracker1CustomText",
                table: "exvs2ob_default_sticker_profile");

            migrationBuilder.DropColumn(
                name: "Tracker2CustomText",
                table: "exvs2ob_default_sticker_profile");

            migrationBuilder.DropColumn(
                name: "Tracker3CustomText",
                table: "exvs2ob_default_sticker_profile");
        }
    }
}
