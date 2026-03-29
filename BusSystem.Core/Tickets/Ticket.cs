using System.ComponentModel.DataAnnotations;
using BusSystem.Core.Travels;
using BusSystem.Core.Users;

namespace BusSystem.Core.Tickets;

    public enum SeatType
    {
         Normal,
         Estudiante,
         INAPAM
    }
    public class Ticket
    {
      [Key]
      public int Id { get; set; }
      
      [Required]
      public string UserId { get; set; }
      public ApplicationUser ApplicationUser { get; set; } = null!;
      
      [Required]
      public int TravelId { get; set; }
      public Travel Travel { get; set; } = null!;
      
      [Required]
      public int SeatNumber { get; set; }
      [Required]
      public SeatType SeatType { get; set; } 
      [Required]
      public DateTime PurchaseDate { get; set; }

    }