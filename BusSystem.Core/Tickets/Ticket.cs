using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusSystem.Core.Travels;
using BusSystem.Core.Users;

namespace BusSystem.Core.Tickets;

    public enum FareType
    {
         Normal,
         Estudiante,
         INAPAM
    }
    public enum TicketStatus
    {
        Active = 1,
        Cancelled = 2
    }
    public class Ticket
    {
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
        public FareType FareType { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; } 

        public TicketStatus Status { get; set; } 
    }