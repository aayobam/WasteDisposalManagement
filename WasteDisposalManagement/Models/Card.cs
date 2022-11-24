using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace WasteDisposalManagement.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required, MaxLength(16), MinLength(12)]
        public string? CardNumber { get; set; }

        [Required, MaxLength(3), MinLength(3)]
        public string? Cvv { get; set; }

        [Required, MaxLength(5), MinLength(5)]
        public string? Expiry { get; set; }

        [Required, MaxLength(4), MinLength(4)]
        public int? Pin { get; set; } = 0000;

        public decimal? CardBalance { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
