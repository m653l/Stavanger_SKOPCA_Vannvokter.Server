using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovesIsPies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPies",
                table: "Producers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPies",
                table: "Producers",
                type: "INTEGER",
                nullable: true);
        }
    }
}
