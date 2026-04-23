using BusSystem.ApplicationServices.PricingSettings;
using BusSystem.ApplicationServices.Shared.DTO.PricingSettings;
using Microsoft.AspNetCore.Mvc;

namespace BusSystem.Controllers.PricingSettings;

[Route("api/[controller]")]
[ApiController]
public class PricingSettingController(IPricingSettingAppService pricingSettingAppService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPricingsAsync()
    {
        try
        {
            var pricingSettings = await pricingSettingAppService.GetPricingSettingsAsync();
            return Ok(pricingSettings);
        }
        catch (Exception ex)
        {
            var errorResponse = new
            {
                Message = "An error occurred while processing the request.",
                Details = ex.Message
            };
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
    [HttpGet("{pricingId}")]
    public async Task<IActionResult> GetPricingByIdAsync(int pricingId)
    {
        try
        {
            var pricingSetting = await pricingSettingAppService.GetPricingSettingByIdAsync(pricingId);
            if (pricingSetting == null)
            {
                return NotFound($"Place with id {pricingId} not found");
            }
            return Ok(pricingSetting);
        }
        catch (Exception ex)
        {
            var errorResponse = new
            {
                Message = "An error occurred while processing the request.",
                Details = ex.Message
            };
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
    
    [HttpPost()]
    public async Task<IActionResult> Post(NewPricingSettingDTO newPricingSettingDto)
    {
        try
        {
            var pricing = await pricingSettingAppService.AddPricingSettingAsync(newPricingSettingDto);
            return Ok($"The place has been added successfully with id {pricing}.");
        }
        catch (Exception ex)
        {
            var errorResponse = new
            {
                Message = "An error occurred while processing the request.",
                Details = ex.Message
            };
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}