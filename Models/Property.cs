using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbackendgp.Models
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PropertyName { get; set; }

        [Required]
        public string PropertyType { get; set; }

        [Required]
        public string PropertyAddress { get; set; }

        public int NumberOfInvestors { get; set; } = 0;

        [Required]
        public double PropertyPrice { get; set; }

        [Required]
        public string SellingStatus { get; set; }

        [Required]
        public string FundingStatus { get; set; }

        [Required]
        public string RentingStatus { get; set; }

        public double FundingPercentage { get; set; } = 0;

        public int? NumOfRooms { get; set; }
        public int? NumOfBathrooms { get; set; }
        public double? PropertyArea { get; set; }
        public int? FloorNumber { get; set; }

        public string ImageUrl { get; set; }
        public string PropertyOverview { get; set; }

        // 📍 Geolocation
        public double? PropertyLongitude { get; set; }
        public double? PropertyLatitude { get; set; }

        // 💲 Pricing details
        public double AvailablePrice { get; set; }

        public double PriceOfMeterSquare { get; set; } // Must exist in the model

        // 📊 Yield & Growth calculations
        public double ProjectedNetYield { get; set; }
        public double PropertyValueGrowth { get; set; }
        public double CurrentRent { get; set; }

        /// ✅ **Annual Gross Rent Formula**: **Annual Gross Rent = Monthly Rent × 12**
        public double AnnualGrossRent { get; set; } // Must exist in the model

        /// ✅ **Annual Gross Yield Formula**: **(Annual Rental Income / Purchase Price) * 100**
        public double AnnualGrossYield { get; set; } // Must exist in the model

        // 💰 Fees & Expenses
        public double ServiceFees { get; set; }
        public double ManagementFees { get; set; }
        public double MaintenanceFees { get; set; }

        /// ✅ **Net Rental Income Formula**: **Annual Rental Income - Total Operating Expenses**
        public double NetRentalIncome { get; set; } // Must exist in the model

        /// ✅ **Net Yield Formula**: **(Net Rental Income / Purchase Price) * 100**
        public double NetYield { get; set; } // Must exist in the model

        /// ✅ **Appreciation Rate**
        public double AppreciationRate { get; set; }

        /// ✅ **Appreciation Value Formula**: **(New Property Value - Initial Property Value)**
        public double AppreciationValue { get; set; } // Must exist in the model

        public DateTime FundingDate { get; set; }

        /// ✅ **Total Investment Return Formula**: **Value Appreciation + Net Rental Income**
        public double TotalInvestmentReturn { get; set; } // Must exist in the model

        /// ✅ **Property Value Growth Formula**: **(New Property Value - Initial Property Value) / Initial Property Value * 100**
        public double PropertyValueGrowthPercentage { get; set; } // Must exist in the model
    }
}
