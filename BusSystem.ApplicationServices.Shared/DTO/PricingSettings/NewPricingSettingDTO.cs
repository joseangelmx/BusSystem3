using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSystem.ApplicationServices.Shared.DTO.PricingSettings;

public class NewPricingSettingDTO
{
    [Required]
    [Column(TypeName = "decimal(8,2)")]
    public decimal PricePerKm { get; set; }
}