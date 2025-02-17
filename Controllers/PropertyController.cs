using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tbackendgp.Models;
using tbackendgp.Data.IRepository;
using tbackendgp.DTOs;
using tbackendgp.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace tbackendgp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly string _imageFolderPath;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
            _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Properties");

            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);  // Ensure the folder exists
            }
        }

        // 🟢 GET ALL PROPERTIES (Retrieves Full Image URL)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> GetAllProperties()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}/Resources/Properties/";

            var properties = await _propertyRepository.GetAllPropertiesAsync();

            var propertyDTOs = properties.Select(p => new PropertyDTO
            {
                Id = p.Id,
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
                AvailablePrice = p.AvailablePrice,
                NumOfRooms = p.NumOfRooms,
                NumOfBathrooms = p.NumOfBathrooms,
                PropertyArea = p.PropertyArea,
                FloorNumber = p.FloorNumber,
                ImageUrl = string.IsNullOrEmpty(p.ImageUrl) ? "" : baseUrl + p.ImageUrl, // Convert to full URL
                PropertyOverview = p.PropertyOverview,
                PropertyLongitude = p.PropertyLongitude,
                PropertyLatitude = p.PropertyLatitude,
                FundingDate = p.FundingDate,
                CurrentRent = p.CurrentRent,
                ServiceFees = p.ServiceFees,
                ManagementFees = p.ManagementFees,
                MaintenanceFees = p.MaintenanceFees,
                OperatingExpenses = p.OperatingExpenses,
                AppreciationRate = p.AppreciationRate,
                NumberOfInvestors = p.NumberOfInvestors,
                PriceOfMeterSquare = p.PriceOfMeterSquare,
                AnnualGrossYield = p.AnnualGrossYield,
                NetYield = p.NetYield,
                NewPropertyPrice = p.NewPropertyPrice,
                AppreciationValue = p.AppreciationValue,
                NetRentalIncome = p.NetRentalIncome,
                yearlyInvestmentReturn = p.yearlyInvestmentReturn,
                AnnualGrossRent = p.AnnualGrossRent,
                AnnualNetIncome = p.AnnualNetIncome,
                PropertyValueGrowthPercentage = p.PropertyValueGrowthPercentage
            });

            return Ok(propertyDTOs);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDTO>> GetPropertyById(int id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            var baseUrl = $"{Request.Scheme}://{Request.Host}/Resources/Properties/";

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
                AvailablePrice = property.AvailablePrice,
                NumOfRooms = property.NumOfRooms,
                NumOfBathrooms = property.NumOfBathrooms,
                PropertyArea = property.PropertyArea,
                FloorNumber = property.FloorNumber,
                ImageUrl = string.IsNullOrEmpty(property.ImageUrl) ? "" : baseUrl + property.ImageUrl, // Ensure Full URL is returned
                PropertyOverview = property.PropertyOverview,
                PropertyLongitude = property.PropertyLongitude,
                PropertyLatitude = property.PropertyLatitude,
                FundingDate = property.FundingDate,
                SellingStatus = property.SellingStatus,
                NumberOfInvestors = property.NumberOfInvestors,
                CurrentRent = property.CurrentRent,
                ServiceFees = property.ServiceFees,
                ManagementFees = property.ManagementFees,
                MaintenanceFees = property.MaintenanceFees,
                OperatingExpenses = property.OperatingExpenses,
                AppreciationRate = property.AppreciationRate,
                PriceOfMeterSquare = property.PriceOfMeterSquare,
                AnnualGrossYield = property.AnnualGrossYield,
                NetYield = property.NetYield,
                NewPropertyPrice = property.NewPropertyPrice,
                AppreciationValue = property.AppreciationValue,
                NetRentalIncome = property.NetRentalIncome,
                yearlyInvestmentReturn = property.yearlyInvestmentReturn,
                AnnualGrossRent = property.AnnualGrossRent,
                AnnualNetIncome = property.AnnualNetIncome,
                PropertyValueGrowthPercentage = property.PropertyValueGrowthPercentage
            };

            return Ok(propertyDto);
        }


        // 🔴 CREATE PROPERTY WITH IMAGE UPLOAD
        [HttpPost("create")]
        public async Task<ActionResult<Property>> CreateProperty([FromForm] CreateOrUpdatePropertyDTO dto, IFormFile? imageFile)
        {
            if (dto == null)
            {
                return BadRequest(new { message = "Invalid property data." });
            }

            string imageUrl = "";

            if (imageFile != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(_imageFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                imageUrl = fileName; // Store only the file name, not full path
            }

            var newProperty = new Property
            {
                PropertyName = dto.PropertyName,
                PropertyType = dto.PropertyType,
                NumOfRooms = dto.NumOfRooms,
                NumOfBathrooms = dto.NumOfBathrooms,
                FloorNumber = dto.FloorNumber,
                PropertyOverview = dto.PropertyOverview,
                PropertyArea = dto.PropertyArea,
                ImageUrl = imageUrl,  // Store the file name

                PropertyAddress = new Address
                {
                    Street = dto.PropertyAddress.Street,
                    City = dto.PropertyAddress.City,
                    State = dto.PropertyAddress.State,
                    Country = dto.PropertyAddress.Country
                },
                PropertyLongitude = dto.PropertyLongitude,
                PropertyLatitude = dto.PropertyLatitude,
                PropertyPrice = dto.PropertyPrice,
                CurrentRent = dto.CurrentRent,
                ServiceFees = dto.ServiceFees,
                MaintenanceFees = dto.MaintenanceFees,
                ManagementFees = dto.ManagementFees,
                OperatingExpenses = dto.OperatingExpenses,
                AppreciationRate = dto.AppreciationRate,
                FundingStatus = "Not Funded",
                RentingStatus = "Vacant",
                SellingStatus = "Available",
                FundingPercentage = 0,
                NumberOfInvestors = 0,
                FundingDate = DateTime.Now
            };

            await _propertyRepository.AddPropertyAsync(newProperty);

            return CreatedAtAction(nameof(GetPropertyById), new { id = newProperty.Id }, newProperty);
        }

        // 🔵 UPDATE PROPERTY (With Image Upload)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromForm] CreateOrUpdatePropertyDTO dto, IFormFile? imageFile)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();

            property.PropertyName = dto.PropertyName;
            property.PropertyType = dto.PropertyType;
            property.NumOfRooms = dto.NumOfRooms;
            property.NumOfBathrooms = dto.NumOfBathrooms;
            property.FloorNumber = dto.FloorNumber;
            property.PropertyOverview = dto.PropertyOverview;
            property.PropertyArea = dto.PropertyArea;

            // Handle image upload
            if (imageFile != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(_imageFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                property.ImageUrl = fileName; // Update new image path
            }

            property.PropertyAddress = new Address
            {
                Street = dto.PropertyAddress.Street,
                City = dto.PropertyAddress.City,
                State = dto.PropertyAddress.State,
                Country = dto.PropertyAddress.Country
            };
            property.PropertyLongitude = dto.PropertyLongitude;
            property.PropertyLatitude = dto.PropertyLatitude;

            await _propertyRepository.UpdatePropertyAsync(property);
            return NoContent();
        }

        // 🔴 DELETE PROPERTY
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var success = await _propertyRepository.DeletePropertyAsync(id);
            if (!success)
                return NotFound(new { message = "Property not found or already deleted." });

            return Ok(new { message = "Property successfully deleted." });
        }
    }
}
