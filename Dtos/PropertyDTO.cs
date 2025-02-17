using System;
using System.ComponentModel.DataAnnotations;

namespace tbackendgp.DTOs
{
    public class AddressDTO
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }
    }

    public class PropertyDTO
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }

        [Required]
        public AddressDTO PropertyAddress { get; set; }

        public double PropertyPrice { get; set; }
        public string FundingStatus { get; set; }
        public string RentingStatus { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Funding percentage must be between 0 and 100.")]
        public decimal FundingPercentage { get; set; }

        public double PriceOfMeterSquare { get; set; }

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
        public double OperatingExpenses { get; set; }
        public double AppreciationRate { get; set; }
        public DateTime FundingDate { get; set; }
        public string SellingStatus { get; set; } = "Available";
        public int NumberOfInvestors { get; set; } = 0;
        public double AvailablePrice { get; set; }

        // 🟢 Computed fields from the Property model:
        public double AnnualGrossYield { get; set; }
        public double NetYield { get; set; }
        public double NewPropertyPrice { get; set; }
        public double AppreciationValue { get; set; }
        public double NetRentalIncome { get; set; }

        public double yearlyInvestmentReturn { get; set; }

        public double AnnualGrossRent { get; set; }
        public double AnnualNetIncome { get; set; }
        public double PropertyValueGrowthPercentage { get; set; }
    }
}
