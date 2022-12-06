using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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

        [Authorize]
        public IActionResult Orders()
        {
            IEnumerable<Order> orders = _context.Orders.Include(s => s.Services).ToList();
            return View(orders);
        }

        [Authorize]
        public IActionResult FirstTimeOrders()
        {
            IEnumerable<FirstTimeOrder> firstTimeOrders = _context.FirstTimeOrders.ToList();
            return View(firstTimeOrders);
        }

        public async Task<IActionResult> Cards()
        {
            //Console.WriteLine($"USER ID: {userid}");
            var userid = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userid);
            IEnumerable<Card> cardObj = _context.Cards.Where(x => x.UserId1 == user.Id).ToList();
            return View(cardObj);
        }
    }
}
