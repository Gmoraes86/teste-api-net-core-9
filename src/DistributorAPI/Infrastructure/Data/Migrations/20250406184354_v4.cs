using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistributorAPI.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Sku");

            migrationBuilder.RenameColumn(
                name: "CorporateName",
                table: "Customer",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Customer",
                newName: "Document");

            migrationBuilder.AddColumn<string>(
                name: "CustomerType",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Customer",
                newName: "CorporateName");

            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Customer",
                newName: "Cnpj");
        }
    }
}
