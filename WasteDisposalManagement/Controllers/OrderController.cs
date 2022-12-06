using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WasteDisposalManagement.Models;
using WasteDisposalManagement.ViewModels;

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
            var payments = new PaymentModel { 
                Name = serviceObj.Name,
                Price = serviceObj.Price.Value,
                DurationInDays = serviceObj.DurationInDays
            };
            return View(payments);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(PaymentModel paymentObj)
        {
            //generates reference number
            Random rnd = new Random();
            string referenceNo = Convert.ToString(rnd.NextInt64(1111111111, 9999999999));
            var userId = User.Claims.SingleOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                //checks if card is valid
                var ValidCardDetail = _context.Cards.Where(
                    x => x.CardNumber == paymentObj.CardNumber
                    && x.Expiry == paymentObj.Expiry
                    && x.Cvv == paymentObj.Cvv
                    && x.Pin == paymentObj.Pin
                    && x.UserId1 == userId
                    );
                bool result = ValidCardDetail.Any();

                if (ValidCardDetail != null)
                {
                    if (!result)
                    {
                        ViewBag.Message = "This card doesn't exist in your name, please try a card that carries your name";
                        return RedirectToAction("Detail");
                    }
                    var existingRecord = _context.FirstTimeOrders.Where(u => u.UserId1 == userId).FirstOrDefault();
                    if(existingRecord == null) {
                        ViewBag.Message = "You have not subscribed for your waste bins yet please select the 'First Time Subscriber Plan'";
                        return RedirectToAction("Service");
                    };
                    
                    Order orderObj = new Order()
                    {
                        ServiceId = paymentObj.Id,
                        Amount = paymentObj.Price,
                        PaymentStatus = "Success",
                        OrderStatus = "Active",
                        ReferenceNo = referenceNo,
                        EndDate = DateTime.Now.AddDays(paymentObj.DurationInDays),
                        UserId1 = userId
                    };
                    _context.Orders.Add(orderObj);
                    _context.SaveChanges();
                    ViewBag.Message = "order successfully placed";
                    return RedirectToAction("Dashboard", "User");
                }
                
                ViewBag.Message = "Invalid card details, ensure your detail matches the card detail and try again.";
                return RedirectToAction("PaymentFailure");
            }
            return View(paymentObj);
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
