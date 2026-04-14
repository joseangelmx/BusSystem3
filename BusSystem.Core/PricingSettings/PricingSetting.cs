using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSystem.Core.PricingSettings;

public class PricingSetting
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "decimal(8,2)")]
    public decimal PricePerKm { get; set; }
    [Required]
    public DateTime EffectiveFrom { get; set; }
}