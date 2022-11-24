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

        [HttpGet]
        public IActionResult OrderDetail(int? id) {
            if(id == 0 || id == null)
            {
                return NotFound(); 
            }
            var serviceDetail = _context.Services.Find(id);
            if(serviceDetail == null) { 
                return NotFound();
            }
            return View(serviceDetail);
        }

        /*[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ProcessOrder(Service ServiceObj)
        {
            if(ServiceObj == null) {
                return NotFound();
            }
            _context.Orders.Add(ServiceObj);
            _context.SaveChanges();
            return RedirectToAction("User", "Order");
        }*/

        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public IActionResult PaymentFailure() { 
            return View();
        }
    }
}
