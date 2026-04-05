using BusSystem.ApplicationServices.SeatSettings;
using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
using BusSystem.Core.SeatSettings;
using Microsoft.AspNetCore.Mvc;

namespace BusSystem.Controllers.SeatSettings;

[Route("api/SeatSettings")]
    [ApiController]
    public class SeatSettingController : ControllerBase
    {
        private readonly ISeatSettingAppService _seatSettingAppService;

        public SeatSettingController(ISeatSettingAppService seatSettingAppService)
        {
            _seatSettingAppService = seatSettingAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<SeatSettingsDTO> seatSettings = await _seatSettingAppService.GetSeatSettingsAsync();
                return Ok(seatSettings);
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

        [HttpGet("{seatId}")]
        public async Task<IActionResult> GetById(int seatId)
        {
            try
            {
                SeatSettingsDTO seatSetting = await _seatSettingAppService.GetSeatSettingByIdAsync(seatId);
                if (seatSetting == null)
                {
                    return NotFound($"Seat setting with ID {seatId} not found.");
                }

                return Ok(seatSetting);
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

        [HttpPost]
        public async Task<IActionResult> Post(NewSeatSettingDTO seatSetting)
        {
            try
            {
                if (seatSetting == null)
                {
                    return BadRequest("Invalid JSON Model!");
                }

                await _seatSettingAppService.AddSeatSettingAsync(seatSetting);
                return Ok(new {Message=""})
            }
            catch
            {
                
            }
        }
    }
