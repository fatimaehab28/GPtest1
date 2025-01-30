using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tbackendgp.Models
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyID { get; set; }

        [Required]
        [MaxLength(100)]
        public string PropertyName { get; set; }

        [Required]
        public string PropertyType { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int NumberOfShares { get; set; }

        public double RentalIncome { get; set; } = 0;

        [Required]
        public double Price { get; set; }

        [Required]
        public string Status { get; set; }

        public double InvestmentPercentage { get; set; } = 0;

        public int? NumOfRooms { get; set; } = null;

        public int? NumOfBathrooms { get; set; } = null;

        public double? PropertyArea { get; set; } = null;

        public int? FloorNumber { get; set; } = null;

        public string ImageUrl { get; set; }

        public string PropertyOverview { get; set; }
    }
}
