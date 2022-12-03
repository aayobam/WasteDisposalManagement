using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteDisposalManagement.Models
{
    public class FirstTimeOrder
    {
        [Key]
        public int OrderId { get; set; }


        [ForeignKey("User")]
        public string UserId1 { get; set; } = null!;

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

