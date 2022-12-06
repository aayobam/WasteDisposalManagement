using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;

namespace WasteDisposalManagement.ViewModels
{
    public class PaymentModel
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        
        public int DurationInDays { get; set; }

        [Required, MinLength(12), MaxLength(16)]
        public string CardNumber { get; set; }
        
        [Required, MinLength(3), MaxLength(3)]
        public string Cvv { get; set; }
        
       [Required, MinLength(5), MaxLength(5)]
        public string Expiry { get; set; }

        [Required, MinLength(4), MaxLength(4)]
        public string Pin { get; set; }
        public int Id { get; set; }
    }
}
