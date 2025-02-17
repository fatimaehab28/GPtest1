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

        public double? PropertyArea { get; set; }
        public int? NumOfRooms { get; set; }
        public int? NumOfBathrooms { get; set; }
        public int? FloorNumber { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public string PropertyOverview { get; set; }

        [Required]
        public Address PropertyAddress { get; set; }

        public double? PropertyLongitude { get; set; }
        public double? PropertyLatitude { get; set; }

        [Required]
        public double PropertyPrice { get; set; }

        public double CurrentRent { get; set; }
        public double ServiceFees { get; set; }
        public double ManagementFees { get; set; }
        public double MaintenanceFees { get; set; }
        public double OperatingExpenses { get; set; }
        public double AppreciationRate { get; set; }

        // ✅ Computed properties with safeguards:

        public double AnnualGrossYield
        {
            get
            {
                return PropertyPrice > 0 ? ((CurrentRent * 12) / PropertyPrice) * 100 : 0;
            }
        }

        public double NetYield
        {
            get
            {
                return PropertyPrice > 0 ? (((CurrentRent * 12) - OperatingExpenses) / PropertyPrice) * 100 : 0;
            }
        }

        public double NewPropertyPrice
        {
            get
            {
                return PropertyPrice > 0 ? PropertyPrice * (1 + AppreciationRate) : PropertyPrice;
            }
        }

        public double AppreciationValue
        {
            get
            {
                return PropertyPrice > 0 ? NewPropertyPrice - PropertyPrice : 0;
            }
        }

        public double NetRentalIncome
        {
            get
            {
                return PropertyPrice > 0 ? (((CurrentRent * 12) + AppreciationValue) / PropertyPrice) * 100 : 0;
            }
        }

        public double yearlyInvestmentReturn
        {
            get
            {
                return PropertyPrice > 0 ? (NetRentalIncome + (AppreciationValue / PropertyPrice)) * 100 : 0;
            }
        }

        public double AnnualGrossRent
        {
            get
            {
                return CurrentRent > 0 ? CurrentRent * 12 : 0;
            }
        }

        public double AnnualNetIncome
        {
            get
            {
                return PropertyPrice > 0 ? (AnnualGrossRent - (ServiceFees + ManagementFees + MaintenanceFees)) + AppreciationValue : 0;
            }
        }

        public double PropertyValueGrowthPercentage
        {
            get
            {
                return PropertyPrice > 0 ? ((NewPropertyPrice - PropertyPrice) / PropertyPrice) * 100 : 0;
            }
        }

        public double AvailablePrice
        {
            get
            {
                return PropertyPrice > 0 ? PropertyPrice * (1 - (double)FundingPercentage) : 0;
            }
        }

        public double PriceOfMeterSquare
        {
            get
            {
                return (PropertyArea.HasValue && PropertyArea.Value > 0)
                    ? PropertyPrice / PropertyArea.Value
                    : 0;
            }
        }

        [Required]
        public string SellingStatus { get; set; }

        [Required]
        public string FundingStatus { get; set; }

        [Required]
        public string RentingStatus { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal FundingPercentage { get; set; } = 0;

        public int NumberOfInvestors { get; set; } = 0;

        public double ProjectedNetYield { get; set; }
        public double PropertyValueGrowth { get; set; }
        public DateTime FundingDate { get; set; }
        public double TotalInvestmentReturn { get; set; }
    }
}
