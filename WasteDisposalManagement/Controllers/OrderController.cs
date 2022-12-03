using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WasteDisposalManagement.Models;

namespace WasteDisposalManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly WasteManagementDbContext _context;
        //private readonly UserManager<User> _userManager;

        public OrderController(WasteManagementDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Service()
        {
            IEnumerable<Service> serviceList = _context.Services.ToList();
            return View(serviceList);
        }

        [Authorize]
        public IActionResult Detail(int? id)
        {
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(Card cardObj, Service serviceObj, User userObj)
        {
            //generates reference number
            Random rnd = new Random();
            string referenceNo = Convert.ToString(rnd.NextInt64(1111111111, 9999999999));

            if (ModelState.IsValid)
            {
                //checks if card is valid
                var ValidCardDetail = _context.Cards.Where(
                    x => x.CardNumber == cardObj.CardNumber
                    && x.Expiry == cardObj.Expiry
                    && x.Cvv == cardObj.Cvv
                    && x.Pin == cardObj.Pin
                    );

                if (ValidCardDetail!=null)
                {
                    Order orderObj = new Order()
                    {
                        ServicesName = serviceObj.Name,
                        Amount = serviceObj.Price,
                        PaymentStatus = "Active",
                        OrderStatus = "Active",
                        ReferenceNo = referenceNo,
                        EndDate = DateTime.Now.AddDays(serviceObj.DurationInDays),
                        UserId1 = userObj.Id,
                    };
                    _context.Orders.Add(orderObj);
                    _context.SaveChanges();
                    return View("PaymentSuccess");
                }
                //ViewBag.message = "Invalid card details, ensure your detail matches the card detail and try again.";
                return View("PaymentFailure");
            }
            return View();
        }

        [Authorize]
        public IActionResult PaymentSuccess()
        {
            return View();
        }

        [Authorize]
        public IActionResult PaymentFailure()
        {
            return View();
        }
    }
}
