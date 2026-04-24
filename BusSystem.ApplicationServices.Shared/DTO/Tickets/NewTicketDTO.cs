using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSystem.ApplicationServices.Shared.DTO.Tickets;

public class NewTicketDTO
{
    
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }
    
    [Required]
    public int TravelId { get; set; }

    [Required]
    public int SeatNumber { get; set; }

    [Required]
    public Core.Tickets.FareType FareType { get; set; }

    [Required]
    public DateTime PurchaseDate { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; } 

    public Core.Tickets.TicketStatus Status { get; set; } 
}