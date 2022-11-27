using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WasteDisposalManagement.Models;

namespace WasteDisposalManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly WasteManagementDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrderController(WasteManagementDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Service()
        {
            IEnumerable<Service> serviceList = _context.Services.ToList();
            return View(serviceList);
        }

        
        public IActionResult Detail(int? id) {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var serviceObj = _context.Services.Find(id);
            if (serviceObj == null)
            {
                return NotFound();
            }
            return View(serviceObj);
        }


        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public IActionResult PaymentFailure() { 
            return View();
        }
    }
}
