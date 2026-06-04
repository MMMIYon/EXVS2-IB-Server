using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerInfinite.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultStickerPilotImageFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CutinImageUseFlag",
                table: "exvs2ob_default_sticker_profile",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PilotImageDispFlag",
                table: "exvs2ob_default_sticker_profile",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CutinImageUseFlag",
                table: "exvs2ob_default_sticker_profile");

            migrationBuilder.DropColumn(
                name: "PilotImageDispFlag",
                table: "exvs2ob_default_sticker_profile");
        }
    }
}
