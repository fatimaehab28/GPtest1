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
        public string PropertyAddress { get; set; }

        [Required]
        public int NumberOfInvestors { get; set; } = 0;

        [Required]
        public double PropertyPrice { get; set; }

        [Required]
        public string OfferStatus { get; set; } = "Pending"; // "Pending", "Accepted", "Declined"

        public double FundingPercentage { get; set; } = 0;

        public int? NumOfRooms { get; set; }
        public int? NumOfBathrooms { get; set; }
        public double? PropertyArea { get; set; }
        public int? FloorNumber { get; set; }

        public string ImageUrl { get; set; }
        public string PropertyOverview { get; set; }

        // Location
        public double? PropertyLongitude { get; set; }
        public double? PropertyLatitude { get; set; }

        // Rental & Financial Information
        public double CurrentRent { get; set; } = 0;
        public double AnnualGrossRent => CurrentRent * 12;
        public double ServiceFees { get; set; } = 0;
        public double ManagementFees { get; set; } = 0;
        public double MaintenanceFees { get; set; } = 0;
        public double AnnualNetIncome => AnnualGrossRent - (ServiceFees + ManagementFees + MaintenanceFees);

        public double AppreciationRate { get; set; } = 0;
        public double AppreciationValue => PropertyPrice * (AppreciationRate / 100);
        public DateTime OfferDate { get; set; } = DateTime.UtcNow;
    }
}
