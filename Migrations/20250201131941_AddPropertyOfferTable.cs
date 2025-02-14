using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tbackendgp.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyOfferTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyOffers",
                columns: table => new
                {
                    OfferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfShares = table.Column<int>(type: "int", nullable: false),
                    RentalIncome = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvestmentPercentage = table.Column<double>(type: "float", nullable: false),
                    NumOfRooms = table.Column<int>(type: "int", nullable: true),
                    NumOfBathrooms = table.Column<int>(type: "int", nullable: true),
                    PropertyArea = table.Column<double>(type: "float", nullable: true),
                    FloorNumber = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyOverview = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOffers", x => x.OfferID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyOffers");
        }
    }
}
