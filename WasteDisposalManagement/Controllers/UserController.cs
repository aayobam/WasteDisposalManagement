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
            return View("Orders");
        }

        [Authorize]
        public IActionResult Orders()
        {
            IEnumerable<Order> orderList = _context.Orders.ToList();
            return View(orderList);
        }

        [Authorize]
        public IActionResult FirstTimeOrders()
        {
            IEnumerable<FirstTimeOrder> orderList = _context.FirstTimeOrders.ToList();
            return View(orderList);
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
