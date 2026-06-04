using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerInfinite.Migrations
{
    /// <inheritdoc />
    public partial class SwapGamepadStyleAndCommandDispConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationType",
                table: "exvs2ob_gamepad_setting",
                newName: "CommandDispConfig");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommandDispConfig",
                table: "exvs2ob_gamepad_setting",
                newName: "OperationType");
        }
    }
}
