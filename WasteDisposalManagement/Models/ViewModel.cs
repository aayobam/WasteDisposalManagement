using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;

namespace WasteDisposalManagement.Models
{
    public class ViewModel
    {
        public IEnumerable<Card> Cards { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<FirstTimeOrder> FirstTimeOrders { get; set; }
    }
}
