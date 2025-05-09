using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unlogy.Migrations
{
    /// <inheritdoc />
    public partial class addisdeletedPropretyinlessonapprovalstatustoCorse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApprovalStatus",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Courses");
        }
    }
}
