using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEnCouches.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Articles");
        }
    }
}
