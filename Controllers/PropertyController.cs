using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using tbackendgp.Models;
using tbackendgp.Data.IRepository;
using tbackendgp.DTOs;

namespace tbackendgp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // 🟢 GET ALL PROPERTIES
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetAllProperties()
        {
            var properties = await _propertyRepository.GetAllPropertiesAsync();
            return Ok(properties);
        }

        // 🔵 GET PROPERTY BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetPropertyById(int id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        // 🟢 GET AVAILABLE PROPERTIES (SellingStatus == "Available")
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Property>>> GetAvailableProperties()
        {
            var properties = await _propertyRepository.GetAvailablePropertiesAsync();
            return Ok(properties);
        }

        // 🔵 GET PROPERTIES BY TYPE
        [HttpGet("type/{propertyType}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesByType(string propertyType)
        {
            var properties = await _propertyRepository.GetPropertiesByTypeAsync(propertyType);
            return Ok(properties);
        }

        // 🟢 GET PROPERTIES BY SELLING STATUS
        [HttpGet("status/selling/{sellingStatus}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesBySellingStatus(string sellingStatus)
        {
            var properties = await _propertyRepository.GetPropertiesBySellingStatusAsync(sellingStatus);
            return Ok(properties);
        }

        // 🟢 GET PROPERTIES BY FUNDING STATUS
        [HttpGet("status/funding/{fundingStatus}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesByFundingStatus(string fundingStatus)
        {
            var properties = await _propertyRepository.GetPropertiesByFundingStatusAsync(fundingStatus);
            return Ok(properties);
        }

        // 🟢 GET PROPERTIES BY RENTING STATUS
        [HttpGet("status/renting/{rentingStatus}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesByRentingStatus(string rentingStatus)
        {
            var properties = await _propertyRepository.GetPropertiesByRentingStatusAsync(rentingStatus);
            return Ok(properties);
        }

        // 🔴 CREATE PROPERTY
        [HttpPost]
        public async Task<ActionResult<Property>> CreateProperty([FromBody] PropertyDTO dto)
        {
            var newProperty = new Property
            {
                PropertyName = dto.PropertyName,
                PropertyType = dto.PropertyType,
                PropertyAddress = dto.PropertyAddress,
                PropertyPrice = dto.PropertyPrice,
                SellingStatus = "Available", // Always starts as "Available"
                FundingStatus = dto.FundingStatus,
                RentingStatus = dto.RentingStatus,
                FundingPercentage = dto.FundingPercentage,
                NumOfRooms = dto.NumOfRooms,
                NumOfBathrooms = dto.NumOfBathrooms,
                PropertyArea = dto.PropertyArea,
                FloorNumber = dto.FloorNumber,
                ImageUrl = dto.ImageUrl,
                PropertyOverview = dto.PropertyOverview,
                PropertyLongitude = dto.PropertyLongitude,
                PropertyLatitude = dto.PropertyLatitude,
                ServiceFees = dto.ServiceFees,
                ManagementFees = dto.ManagementFees,
                MaintenanceFees = dto.MaintenanceFees,
                CurrentRent = dto.CurrentRent,
                FundingDate = dto.FundingDate,
                AppreciationRate = dto.AppreciationRate,

                // 🟢 Automatically Initialized Fields
                NumberOfInvestors = 0, // Always starts as 0
                AvailablePrice = dto.PropertyPrice, // Initially the full property price

                // 🟢 Computed Fields (Backend)
                PriceOfMeterSquare = dto.PropertyArea.HasValue && dto.PropertyArea.Value > 0
                    ? dto.PropertyPrice / dto.PropertyArea.Value
                    : 0,

                AnnualGrossRent = dto.CurrentRent * 12,

                AnnualGrossYield = dto.PropertyPrice > 0
                    ? (dto.CurrentRent * 12) / dto.PropertyPrice * 100
                    : 0,

                NetRentalIncome = (dto.CurrentRent * 12) - (dto.ServiceFees + dto.ManagementFees + dto.MaintenanceFees),

                NetYield = dto.PropertyPrice > 0
                    ? ((dto.CurrentRent * 12) - (dto.ServiceFees + dto.ManagementFees + dto.MaintenanceFees)) / dto.PropertyPrice * 100
                    : 0,

                AppreciationValue = dto.PropertyPrice * (dto.AppreciationRate / 100),

                TotalInvestmentReturn = (dto.PropertyPrice * (dto.AppreciationRate / 100)) +
                    ((dto.CurrentRent * 12) - (dto.ServiceFees + dto.ManagementFees + dto.MaintenanceFees)),

                PropertyValueGrowthPercentage = dto.PropertyPrice > 0
                    ? ((dto.PropertyPrice * (dto.AppreciationRate / 100)) / dto.PropertyPrice) * 100
                    : 0
            };

            await _propertyRepository.AddPropertyAsync(newProperty);
            return CreatedAtAction(nameof(GetPropertyById), new { id = newProperty.Id }, newProperty);
        }

        // 🔵 UPDATE PROPERTY
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] PropertyDTO dto)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            // 🔵 Update fields
            property.PropertyName = dto.PropertyName;
            property.PropertyType = dto.PropertyType;
            property.PropertyAddress = dto.PropertyAddress;
            property.PropertyPrice = dto.PropertyPrice;
            property.FundingStatus = dto.FundingStatus;
            property.RentingStatus = dto.RentingStatus;
            property.FundingPercentage = dto.FundingPercentage;
            property.NumOfRooms = dto.NumOfRooms;
            property.NumOfBathrooms = dto.NumOfBathrooms;
            property.PropertyArea = dto.PropertyArea;
            property.FloorNumber = dto.FloorNumber;
            property.ImageUrl = dto.ImageUrl;
            property.PropertyOverview = dto.PropertyOverview;
            property.PropertyLongitude = dto.PropertyLongitude;
            property.PropertyLatitude = dto.PropertyLatitude;
            property.ServiceFees = dto.ServiceFees;
            property.ManagementFees = dto.ManagementFees;
            property.MaintenanceFees = dto.MaintenanceFees;
            property.CurrentRent = dto.CurrentRent;
            property.FundingDate = dto.FundingDate;
            property.AppreciationRate = dto.AppreciationRate;

            // 🔵 Recalculate Fields (Backend)
            property.PriceOfMeterSquare = dto.PropertyArea.HasValue && dto.PropertyArea.Value > 0
                ? dto.PropertyPrice / dto.PropertyArea.Value
                : 0;

            property.AnnualGrossRent = dto.CurrentRent * 12;

            property.AnnualGrossYield = dto.PropertyPrice > 0
                ? (dto.CurrentRent * 12) / dto.PropertyPrice * 100
                : 0;

            property.NetRentalIncome = (dto.CurrentRent * 12) - (dto.ServiceFees + dto.ManagementFees + dto.MaintenanceFees);

            property.NetYield = dto.PropertyPrice > 0
                ? ((dto.CurrentRent * 12) - (dto.ServiceFees + dto.ManagementFees + dto.MaintenanceFees)) / dto.PropertyPrice * 100
                : 0;

            property.AppreciationValue = dto.PropertyPrice * (dto.AppreciationRate / 100);

            property.TotalInvestmentReturn = (dto.PropertyPrice * (dto.AppreciationRate / 100)) +
                ((dto.CurrentRent * 12) - (dto.ServiceFees + dto.ManagementFees + dto.MaintenanceFees));

            property.PropertyValueGrowthPercentage = dto.PropertyPrice > 0
                ? ((dto.PropertyPrice * (dto.AppreciationRate / 100)) / dto.PropertyPrice) * 100
                : 0;

            // 🔴 Ensure the update is saved
            await _propertyRepository.UpdatePropertyAsync(property);
            return NoContent();
        }

        // 🔴 DELETE PROPERTY
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var success = await _propertyRepository.DeletePropertyAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
