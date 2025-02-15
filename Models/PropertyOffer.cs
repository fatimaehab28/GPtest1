using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbackendgp.Models
{
    public class PropertyOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string PropertyName { get; set; }

        [Required]
        public string PropertyType { get; set; }

       

        [Required]
        public Address PropertyAddress { get; set; }


        [Required]
        public int NumberOfInvestors { get; set; } = 0;

        [Required]
        public double PropertyPrice { get; set; }

        [Required]
        public string OfferStatus { get; set; } = "Pending"; // "Pending", "Accepted", "Declined"

        // ✅ Store as decimal (0.25 for 25%)
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

        // 💰 Rental & Financial Information
        public double CurrentRent { get; set; } = 0;
        public double AnnualGrossRent => CurrentRent * 12;
        public double ServiceFees { get; set; } = 0;
        public double ManagementFees { get; set; } = 0;
        public double MaintenanceFees { get; set; } = 0;

        // ✅ Added Operating Expenses
        public double OperatingExpenses { get; set; } = 0;

        public double AnnualNetIncome => AnnualGrossRent - (ServiceFees + ManagementFees + MaintenanceFees + OperatingExpenses);
        public double AppreciationRate { get; set; } = 0;
        public double AppreciationValue => PropertyPrice * (AppreciationRate / 100);
        public DateTime OfferDate { get; set; } = DateTime.UtcNow;
    }
}
