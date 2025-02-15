using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> GetAllProperties()
        {
            var properties = await _propertyRepository.GetAllPropertiesAsync();

            var propertyDTOs = properties.Select(p => new PropertyDTO
            {
                PropertyName = p.PropertyName,
                PropertyType = p.PropertyType,
                PropertyAddress = new AddressDTO
                {
                    Street = p.PropertyAddress.Street,
                    City = p.PropertyAddress.City,
                    State = p.PropertyAddress.State,
                    Country = p.PropertyAddress.Country
                },
                PropertyPrice = p.PropertyPrice,
                FundingStatus = p.FundingStatus,
                RentingStatus = p.RentingStatus,
                FundingPercentage = p.FundingPercentage * 100,
                AvailablePrice = p.AvailablePrice, // ✅ Include AvailablePrice

                NumOfRooms = p.NumOfRooms,
                NumOfBathrooms = p.NumOfBathrooms,
                PropertyArea = p.PropertyArea,
                FloorNumber = p.FloorNumber,
                ImageUrl = p.ImageUrl,
                PropertyOverview = p.PropertyOverview,
                PropertyLongitude = p.PropertyLongitude,
                PropertyLatitude = p.PropertyLatitude,
                FundingDate = p.FundingDate
            });

            return Ok(propertyDTOs);
        }

        // 🔵 GET PROPERTY BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDTO>> GetPropertyById(int id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            var propertyDto = new PropertyDTO
            {
                PropertyName = property.PropertyName,
                PropertyType = property.PropertyType,
                PropertyAddress = new AddressDTO
                {
                    Street = property.PropertyAddress.Street,
                    City = property.PropertyAddress.City,
                    State = property.PropertyAddress.State,
                    Country = property.PropertyAddress.Country
                },
                PropertyPrice = property.PropertyPrice,
                FundingStatus = property.FundingStatus,
                RentingStatus = property.RentingStatus,
                FundingPercentage = property.FundingPercentage * 100,
                AvailablePrice = property.AvailablePrice, // ✅ Include AvailablePrice
                NumberOfInvestors = property.NumberOfInvestors,
                PriceOfMeterSquare = property.PriceOfMeterSquare,



                NumOfRooms = property.NumOfRooms,
                NumOfBathrooms = property.NumOfBathrooms,
                PropertyArea = property.PropertyArea,
                FloorNumber = property.FloorNumber,
                ImageUrl = property.ImageUrl,
                PropertyOverview = property.PropertyOverview,
                PropertyLongitude = property.PropertyLongitude,
                PropertyLatitude = property.PropertyLatitude,
                FundingDate = property.FundingDate
            };

            return Ok(propertyDto);
        }

        // 🔴 CREATE PROPERTY
        [HttpPost]
        public async Task<ActionResult<Property>> CreateProperty([FromBody] PropertyDTO dto)
        {
            var newProperty = new Property
            {
                PropertyName = dto.PropertyName,
                PropertyType = dto.PropertyType,

                PropertyAddress = new Address
                {
                    Street = dto.PropertyAddress.Street,
                    City = dto.PropertyAddress.City,
                    State = dto.PropertyAddress.State,
                    Country = dto.PropertyAddress.Country
                },

                PropertyPrice = dto.PropertyPrice,
                FundingStatus = "Not Funded",  // Ensure it is "Not Funded"
                RentingStatus = dto.RentingStatus,
                SellingStatus = "Available",

                FundingPercentage = 0,  // Set funding percentage to 0
                NumberOfInvestors = 0,  // Ensure no investors initially

                NumOfRooms = dto.NumOfRooms,
                NumOfBathrooms = dto.NumOfBathrooms,
                PropertyArea = dto.PropertyArea,
                FloorNumber = dto.FloorNumber,
                ImageUrl = dto.ImageUrl,
                PropertyOverview = dto.PropertyOverview,
                PropertyLongitude = dto.PropertyLongitude,
                PropertyLatitude = dto.PropertyLatitude,
                FundingDate = DateTime.Now
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

            property.PropertyName = dto.PropertyName;
            property.PropertyType = dto.PropertyType;

            property.PropertyAddress = new Address
            {
                Street = dto.PropertyAddress.Street,
                City = dto.PropertyAddress.City,
                State = dto.PropertyAddress.State,
                Country = dto.PropertyAddress.Country
            };

            property.PropertyPrice = dto.PropertyPrice;
            property.FundingStatus = dto.FundingStatus;
            property.RentingStatus = dto.RentingStatus;

            property.FundingPercentage = dto.FundingPercentage / 100m; // Convert percentage to decimal before storing
            property.OperatingExpenses = dto.OperatingExpenses; 

            property.NumOfRooms = dto.NumOfRooms;
            property.NumOfBathrooms = dto.NumOfBathrooms;
            property.PropertyArea = dto.PropertyArea;
            property.FloorNumber = dto.FloorNumber;
            property.ImageUrl = dto.ImageUrl;
            property.PropertyOverview = dto.PropertyOverview;
            property.PropertyLongitude = dto.PropertyLongitude;
            property.PropertyLatitude = dto.PropertyLatitude;
            property.FundingDate = dto.FundingDate;

            await _propertyRepository.UpdatePropertyAsync(property);
            return NoContent();
        }


        // 🔴 DELETE PROPERTY
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var success = await _propertyRepository.DeletePropertyAsync(id);
            if (!success) return NotFound(new { message = "Property not found or already deleted." });

            return Ok(new { message = "Property successfully deleted." });
        }

    }
}
