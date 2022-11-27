using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
            return View("Orders");
        }

        public IActionResult Profile(User user)
        {
           return View(user);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(string id, UpdateUser userObj)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.FirstName = userObj.FirstName;
                user.LastName = userObj.LastName;
                user.PhoneNumber = userObj.PhoneNumber;
                user.Address = userObj.Address;
                user.City = userObj.City;
                user.State = userObj.State;
                user.ProfilePicture = userObj.ProfilePicture;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    ViewBag.status = "Profile updated succesful";
                    return RedirectToAction("Profile", "User");
                }
                else
                {

                    ViewBag.status = "Unable to update user data";
                    return View(user);
                }
            }
            ViewBag.status = "Profile not found.";
            return View("Profile");
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
