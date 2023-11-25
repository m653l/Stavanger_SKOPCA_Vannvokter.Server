using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdressesAndStreetsAndBeerAndGuns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FieldAddress_Street",
                table: "Submissions",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "FieldAddress_PostCode",
                table: "Submissions",
                newName: "Address_PostCode");

            migrationBuilder.RenameColumn(
                name: "FieldAddress_City",
                table: "Submissions",
                newName: "Address_City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Submissions",
                newName: "FieldAddress_Street");

            migrationBuilder.RenameColumn(
                name: "Address_PostCode",
                table: "Submissions",
                newName: "FieldAddress_PostCode");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Submissions",
                newName: "FieldAddress_City");
        }
    }
}
