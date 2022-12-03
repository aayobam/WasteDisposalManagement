using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WasteDisposalManagement.Models;

namespace WasteDisposalManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly WasteManagementDbContext _context;
        private readonly UserManager<User> _userManager;
        public AdminController(WasteManagementDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Dashboard()
        {
            return RedirectToAction("Users");
        }

        public IActionResult Users()
        {
            IEnumerable<User> userObj = _userManager.Users.ToList();
            return View(userObj);
        }

        public IActionResult Services()
        {
            IEnumerable<Service> serviceObj = _context.Services.ToList();
            return View(serviceObj);
        }

        public IActionResult Orders()
        {
            IEnumerable<Order> ordersObj = _context.Orders.ToList();
            return View(ordersObj);
        }

        public IActionResult FirstTimeOrders()
        {
            IEnumerable<FirstTimeOrder> firstTimeOrderObj = _context.FirstTimeOrders.ToList();
            return View(firstTimeOrderObj);
        }

        public IActionResult Cards()
        {
            
            //var userid = _userManager.GetUserId(User);
            //var user = await _userManager.FindByIdAsync(userid);
            Console.ReadLine();
            /*IEnumerable<Card> cardObj = _context.Cards.Include(u => u.User).Where(x=>x.UserId1==userid).ToList();*/
            IEnumerable<Card> cardObj = _context.Cards.ToList();
            return View(cardObj);
        }
    }
}
