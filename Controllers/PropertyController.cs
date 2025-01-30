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

        // 🟢 GET AVAILABLE PROPERTIES
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

        // 🟢 GET PROPERTIES BY STATUS
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesByStatus(string status)
        {
            var properties = await _propertyRepository.GetPropertiesByStatusAsync(status);
            return Ok(properties);
        }

        // 🔴 CREATE PROPERTY
        [HttpPost]
        public async Task<ActionResult<Property>> CreateProperty([FromBody] PropertyDTO propertyDto)
        {
            var newProperty = new Property
            {
                PropertyName = propertyDto.PropertyName,
                PropertyType = propertyDto.PropertyType,
                Address = propertyDto.Address,
                NumberOfShares = propertyDto.NumberOfShares,
                RentalIncome = propertyDto.RentalIncome,
                Price = propertyDto.Price,
                Status = propertyDto.Status,
                InvestmentPercentage = propertyDto.InvestmentPercentage,
                NumOfRooms = propertyDto.NumOfRooms,
                NumOfBathrooms = propertyDto.NumOfBathrooms,
                PropertyArea = propertyDto.PropertyArea,
                FloorNumber = propertyDto.FloorNumber,
                ImageUrl = propertyDto.ImageUrl,
                PropertyOverview = propertyDto.PropertyOverview
            };

            await _propertyRepository.AddPropertyAsync(newProperty);
            return CreatedAtAction(nameof(GetPropertyById), new { id = newProperty.PropertyID }, newProperty);
        }

        // 🔵 UPDATE PROPERTY
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] PropertyDTO propertyDto)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            // 🔵 Update fields
            property.PropertyName = propertyDto.PropertyName;
            property.PropertyType = propertyDto.PropertyType;
            property.Address = propertyDto.Address;
            property.NumberOfShares = propertyDto.NumberOfShares;
            property.RentalIncome = propertyDto.RentalIncome;
            property.Price = propertyDto.Price;
            property.Status = propertyDto.Status;
            property.InvestmentPercentage = propertyDto.InvestmentPercentage;
            property.NumOfRooms = propertyDto.NumOfRooms;
            property.NumOfBathrooms = propertyDto.NumOfBathrooms;
            property.PropertyArea = propertyDto.PropertyArea;
            property.FloorNumber = propertyDto.FloorNumber;
            property.ImageUrl = propertyDto.ImageUrl;
            property.PropertyOverview = propertyDto.PropertyOverview;

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
