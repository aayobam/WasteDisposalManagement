using System.Drawing;
using System.Globalization;

namespace WasteDisposalManagement.ViewModels
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public Decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string Expiry { get; set; }
        public string Pin { get; set; }
    }
}
