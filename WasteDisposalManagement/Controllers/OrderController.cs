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
                Id = serviceObj.ServiceId,
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
                    );

                if (ValidCardDetail != null)
                {
                    Order orderObj = new Order()
                    {
                        ServiceId = paymentObj.Id,
                        Amount = paymentObj.Price,
                        PaymentStatus = "Active",
                        OrderStatus = "Active",
                        ReferenceNo = referenceNo,
                        EndDate = DateTime.Now.AddDays(paymentObj.DurationInDays),
                        UserId1 = userId
                    };
                    _context.Orders.Add(orderObj);
                    _context.SaveChanges();
                    return RedirectToAction("PaymentSuccess");
                }
                ViewBag.message = "Invalid card details, ensure your detail matches the card detail and try again.";
                return RedirectToAction("PaymentFailure");
            }
            return View(paymentObj);
        }

        /*private IEnumerable<Card> GetCards()
        {
            throw new NotImplementedException();
        }*/

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
