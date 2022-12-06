using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WasteDisposalManagement.Models;
using WasteDisposalManagement.ViewModels;

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
            var dashboardItems = new AdminItemsModel
            {
                totalOrders = _context.Orders.Count(),
                totalUsers = _context.Users.Count(),
                ActiveOrders = _context.Orders.Where(x => x.OrderStatus == "Active").Count(),
                pendingOrders = _context.Orders.Where(x => x.OrderStatus == "Pending").Count()
            };
            return View(dashboardItems);
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

        public IActionResult Cards(){
            IEnumerable<Card> cards = _context.Cards.Include(c => c.User).ToList();
            return View(cards);
        }
    }
}
