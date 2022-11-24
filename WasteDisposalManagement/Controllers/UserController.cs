using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WasteDisposalManagement.Models;

namespace WasteDisposalManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly WasteManagementDbContext _context;
        private readonly UserManager<User> _userManager;
        public UserController(WasteManagementDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Dashboard()
        {
            return RedirectToAction("Orders");
        }

        public IActionResult Profile() {
            return View();
        }

        public IActionResult Orders()
        {
            IEnumerable<Order> orderList = _context.Orders.ToList();
            return View(orderList);
        }

        public IActionResult FirstTimeOrders()
        {
            IEnumerable<FirstTimeOrder> orderList = _context.FirstTimeOrders.ToList();
            return View(orderList);
        }
    }
}
