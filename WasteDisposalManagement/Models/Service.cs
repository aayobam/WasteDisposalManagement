using System.ComponentModel.DataAnnotations;

namespace WasteDisposalManagement.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public string Name { get; set; } = null!;

        public decimal? Price { get; set; }

        public int DurationInDays { get; set; }
        public virtual ICollection<FirstTimeOrder> FirstTimeOrders { get; } = new List<FirstTimeOrder>();

        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }
}
