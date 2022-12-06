using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteDisposalManagement.Models
{
    public class Order
    {
        
        public int OrderId { get; set; }


        [ForeignKey("User")]
        public string UserId1 { get; set; } = null!;
       
        [ForeignKey("Services")]
        public int ServiceId { get; set; }

        public decimal? Amount { get; set; }

        public string PaymentStatus { get; set; } = null!;

        public string OrderStatus { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public string ReferenceNo { get; set; } = null!;

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; }

        public virtual Service Services { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
