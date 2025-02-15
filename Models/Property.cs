using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

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
        public Address PropertyAddress { get; set; }

        public int NumberOfInvestors { get; set; } = 0;

        [Required]
        public double PropertyPrice { get; set; }

        [Required]
        public string SellingStatus { get; set; }

        [Required]
        public string FundingStatus { get; set; }

        [Required]
        public string RentingStatus { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal FundingPercentage { get; set; } = 0;

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
        //public double AvailablePrice { get; set; }
       // public double PriceOfMeterSquare { get; set; }

        // 📊 Yield & Growth calculations
        public double ProjectedNetYield { get; set; }
        public double PropertyValueGrowth { get; set; }
        public double CurrentRent { get; set; }
        public double AnnualGrossRent { get; set; }
        public double AnnualGrossYield { get; set; }

        // 💰 Fees & Expenses
        public double ServiceFees { get; set; }
        public double ManagementFees { get; set; }
        public double MaintenanceFees { get; set; }

        public double OperatingExpenses { get; set; }

        public double NetRentalIncome { get; set; }
        public double NetYield { get; set; }



        public double AppreciationRate { get; set; }
        public double AppreciationValue { get; set; }

        public DateTime FundingDate { get; set; }
        public double TotalInvestmentReturn { get; set; }
        public double PropertyValueGrowthPercentage { get; set; }



        public double AvailablePrice
        {
            get
            {
                return PropertyPrice * (1 - (double)FundingPercentage); 
            }
        }


        public double PriceOfMeterSquare
        {
            get
            {
                return (PropertyArea.HasValue && PropertyArea.Value > 0)
                    ? PropertyPrice / PropertyArea.Value
                    : 0; // ✅ Prevents division by zero & handles null cases
            }
        }








    }
}
