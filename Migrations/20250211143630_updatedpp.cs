using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tbackendgp.Migrations
{
    /// <inheritdoc />
    public partial class updatedpp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PropertyOffers",
                newName: "PropertyAddress");

            migrationBuilder.RenameColumn(
                name: "RentalIncome",
                table: "PropertyOffers",
                newName: "ServiceFees");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "PropertyOffers",
                newName: "PropertyPrice");

            migrationBuilder.RenameColumn(
                name: "NumberOfShares",
                table: "PropertyOffers",
                newName: "NumberOfInvestors");

            migrationBuilder.RenameColumn(
                name: "InvestmentPercentage",
                table: "PropertyOffers",
                newName: "ManagementFees");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "PropertyOffers",
                newName: "OfferStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Properties",
                newName: "SellingStatus");

            migrationBuilder.RenameColumn(
                name: "RentalIncome",
                table: "Properties",
                newName: "ServiceFees");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Properties",
                newName: "PropertyValueGrowth");

            migrationBuilder.RenameColumn(
                name: "NumberOfShares",
                table: "Properties",
                newName: "NumberOfInvestors");

            migrationBuilder.RenameColumn(
                name: "InvestmentPercentage",
                table: "Properties",
                newName: "PropertyPrice");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Properties",
                newName: "RentingStatus");

            migrationBuilder.RenameColumn(
                name: "PropertyID",
                table: "Properties",
                newName: "Id");

            migrationBuilder.AddColumn<double>(
                name: "AppreciationRate",
                table: "PropertyOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentRent",
                table: "PropertyOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FundingPercentage",
                table: "PropertyOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaintenanceFees",
                table: "PropertyOffers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OfferDate",
                table: "PropertyOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "PropertyLatitude",
                table: "PropertyOffers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PropertyLongitude",
                table: "PropertyOffers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AppreciationRate",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AvailablePrice",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentRent",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FundingDate",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "FundingPercentage",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FundingStatus",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MaintenanceFees",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ManagementFees",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProjectedNetYield",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PropertyAddress",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PropertyLatitude",
                table: "Properties",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PropertyLongitude",
                table: "Properties",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppreciationRate",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "CurrentRent",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "FundingPercentage",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "MaintenanceFees",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "OfferDate",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "PropertyLatitude",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "PropertyLongitude",
                table: "PropertyOffers");

            migrationBuilder.DropColumn(
                name: "AppreciationRate",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "AvailablePrice",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CurrentRent",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FundingDate",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FundingPercentage",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FundingStatus",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MaintenanceFees",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ManagementFees",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ProjectedNetYield",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyAddress",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyLatitude",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyLongitude",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "ServiceFees",
                table: "PropertyOffers",
                newName: "RentalIncome");

            migrationBuilder.RenameColumn(
                name: "PropertyPrice",
                table: "PropertyOffers",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PropertyAddress",
                table: "PropertyOffers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "OfferStatus",
                table: "PropertyOffers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "NumberOfInvestors",
                table: "PropertyOffers",
                newName: "NumberOfShares");

            migrationBuilder.RenameColumn(
                name: "ManagementFees",
                table: "PropertyOffers",
                newName: "InvestmentPercentage");

            migrationBuilder.RenameColumn(
                name: "ServiceFees",
                table: "Properties",
                newName: "RentalIncome");

            migrationBuilder.RenameColumn(
                name: "SellingStatus",
                table: "Properties",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "RentingStatus",
                table: "Properties",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "PropertyValueGrowth",
                table: "Properties",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PropertyPrice",
                table: "Properties",
                newName: "InvestmentPercentage");

            migrationBuilder.RenameColumn(
                name: "NumberOfInvestors",
                table: "Properties",
                newName: "NumberOfShares");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Properties",
                newName: "PropertyID");
        }
    }
}
