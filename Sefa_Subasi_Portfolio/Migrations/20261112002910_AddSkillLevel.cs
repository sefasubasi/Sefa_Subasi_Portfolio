using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sefa_Subasi_Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "SkillItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "SkillItems");
        }
    }
}
