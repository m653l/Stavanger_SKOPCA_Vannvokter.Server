using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAterMargeControlIncydent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmitionStatus",
                table: "Submition");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Submition",
                newName: "FieldAddress_Street");

            migrationBuilder.AddColumn<string>(
                name: "FieldAddress_City",
                table: "Submition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FieldAddress_PostCode",
                table: "Submition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Submition",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<bool>(
                name: "isPies",
                table: "Producers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldAddress_City",
                table: "Submition");

            migrationBuilder.DropColumn(
                name: "FieldAddress_PostCode",
                table: "Submition");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Submition");

            migrationBuilder.RenameColumn(
                name: "FieldAddress_Street",
                table: "Submition",
                newName: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "SubmitionStatus",
                table: "Submition",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "isPies",
                table: "Producers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
