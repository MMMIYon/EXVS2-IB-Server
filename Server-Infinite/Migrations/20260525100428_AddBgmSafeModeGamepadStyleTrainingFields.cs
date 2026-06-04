using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerInfinite.Migrations
{
    /// <inheritdoc />
    public partial class AddBgmSafeModeGamepadStyleTrainingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "Armor",
                table: "exvs2ob_training_profile",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<bool>(
                name: "CpuAutoHeal",
                table: "exvs2ob_training_profile",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExOverLimit",
                table: "exvs2ob_training_profile",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FastReload",
                table: "exvs2ob_training_profile",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<uint>(
                name: "GamePadStyle",
                table: "exvs2ob_gamepad_setting",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<bool>(
                name: "BgmSafeMode",
                table: "exvs2ob_customize_profile",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Armor",
                table: "exvs2ob_training_profile");

            migrationBuilder.DropColumn(
                name: "CpuAutoHeal",
                table: "exvs2ob_training_profile");

            migrationBuilder.DropColumn(
                name: "ExOverLimit",
                table: "exvs2ob_training_profile");

            migrationBuilder.DropColumn(
                name: "FastReload",
                table: "exvs2ob_training_profile");

            migrationBuilder.DropColumn(
                name: "GamePadStyle",
                table: "exvs2ob_gamepad_setting");

            migrationBuilder.DropColumn(
                name: "BgmSafeMode",
                table: "exvs2ob_customize_profile");
        }
    }
}
