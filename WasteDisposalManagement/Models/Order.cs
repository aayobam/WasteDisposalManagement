using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace WasteDisposalManagement.Models
{
    public class Order
    {
        
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public string ServicesName { get; set; } = null!;

        public decimal? Amount { get; set; }

        public string PaymentStatus { get; set; } = null!;

        public string OrderStatus { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public string ReferenceNo { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Service ServicesNameNavigation { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
