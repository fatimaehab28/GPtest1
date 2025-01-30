
namespace tbackendgp.DTOs
{
    public class PropertyDTO
    {
        //public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string Address { get; set; }
        public int NumberOfShares { get; set; }
        public double RentalIncome { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public double InvestmentPercentage { get; set; }
        public int? NumOfRooms { get; set; }
        public int? NumOfBathrooms { get; set; }
        public double? PropertyArea { get; set; }
        public int? FloorNumber { get; set; }
        public string ImageUrl { get; set; }
        public string PropertyOverview { get; set; }
    }
}
