using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusSystem.Core.Tickets;
using BusSystem.Core.Travels;
using BusSystem.Core.Users;

namespace BusSystem.ApplicationServices.Shared.DTO.Tickets;

public class TicketDTO
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }
    
    [Required]
    public int TravelId { get; set; }

    [Required]
    public int SeatNumber { get; set; }

    [Required]
    public FareType FareType { get; set; }

    [Required]
    public DateTime PurchaseDate { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; } 

    public TicketStatus Status { get; set; } 
}