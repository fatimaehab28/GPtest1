using System;

namespace tbackendgp.DTOs
{
    public class PropertyDTO
    {
        // 📌 Required fields that the property manager MUST enter from the frontend
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyAddress { get; set; }
        public double PropertyPrice { get; set; }
        public string FundingStatus { get; set; }
        public string RentingStatus { get; set; }
        public double FundingPercentage { get; set; }
        public int? NumOfRooms { get; set; }
        public int? NumOfBathrooms { get; set; }
        public double? PropertyArea { get; set; }
        public int? FloorNumber { get; set; }
        public string ImageUrl { get; set; }
        public string PropertyOverview { get; set; }
        public double? PropertyLongitude { get; set; }
        public double? PropertyLatitude { get; set; }
        public double CurrentRent { get; set; }
        public double ServiceFees { get; set; }
        public double ManagementFees { get; set; }
        public double MaintenanceFees { get; set; }
        public double AppreciationRate { get; set; }
        public DateTime FundingDate { get; set; }

        // 🔵 Automatically Initialized Fields (Backend logic)
        public string SellingStatus { get; set; } = "Available"; // Always starts as "Available"
        public int NumberOfInvestors { get; set; } = 0; // Always starts at 0
        public double AvailablePrice { get; set; } // Will be initialized in Controller
    }
}
