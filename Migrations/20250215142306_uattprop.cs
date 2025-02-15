using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tbackendgp.Migrations
{
    /// <inheritdoc />
    public partial class uattprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyAddress",
                table: "PropertyOffers",
                newName: "PropertyAddress_Street");

            migrationBuilder.RenameColumn(
                name: "PropertyAddress",
                table: "Properties",
                newName: "PropertyAddress_Street");

            migrationBuilder.AlterColumn<decimal>(
                name: "FundingPercentage",
                table: "PropertyOffers",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "OperatingExpenses",
                table: "PropertyOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PropertyAddress_City",
                table: "PropertyOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyAddress_Country",
                table: "PropertyOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyAddress_State",
                table: "PropertyOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "FundingPercentage",
                table: "Properties",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "OperatingExpenses",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PropertyAddress_City",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyAddress_Country",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyAddress_State",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatingExpenses",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "PropertyAddress_City",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "PropertyAddress_Country",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "PropertyAddress_State",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "OperatingExpenses",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyAddress_City",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyAddress_Country",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyAddress_State",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "PropertyAddress_Street",
                table: "PropertyOffers",
                newName: "PropertyAddress");

            migrationBuilder.RenameColumn(
                name: "PropertyAddress_Street",
                table: "Properties",
                newName: "PropertyAddress");

            migrationBuilder.AlterColumn<double>(
                name: "FundingPercentage",
                table: "PropertyOffers",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<double>(
                name: "FundingPercentage",
                table: "Properties",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}
