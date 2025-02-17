using System.ComponentModel.DataAnnotations;
using tbackendgp.DTOs;

namespace tbackendgp.Dtos
{
    
        


        public class CreateOrUpdatePropertyDTO
        {
            // Step 1: Basic Info
            public string PropertyName { get; set; }
            public string PropertyType { get; set; }
            public int? NumOfRooms { get; set; }
            public int? NumOfBathrooms { get; set; }
            public int? FloorNumber { get; set; }
            public string PropertyOverview { get; set; }
            public double? PropertyArea { get; set; }
            public string ImageUrl { get; set; }

            // Step 2: Address/Location
            [Required]
            public AddressDTO PropertyAddress { get; set; }
            public double? PropertyLongitude { get; set; }
            public double? PropertyLatitude { get; set; }

            // Step 3: Financial Info
            public double PropertyPrice { get; set; }
            public double CurrentRent { get; set; }
            public double ServiceFees { get; set; }
            public double MaintenanceFees { get; set; }
            public double ManagementFees { get; set; }
            public double OperatingExpenses { get; set; }
            public double AppreciationRate { get; set; }
        }

    }

