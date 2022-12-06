using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WasteDisposalManagement.Models;

namespace WasteDisposalManagement.ViewModels
{
    public class CardViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(16), MinLength(12)]
        public string CardNumber { get; set; } = string.Empty;

        [Required, MaxLength(3), MinLength(3)]
        public string Cvv { get; set; } = string.Empty;

        [Required, MaxLength(5), MinLength(5)]
        public string? Expiry { get; set; }

        [Required, MaxLength(4), MinLength(4)]
        public string? Pin { get; set; }
        public decimal CardBalance { get; set; }

        public string UserId1 { get; set; } = string.Empty;
    }
}
