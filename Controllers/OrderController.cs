using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicForm.Data;
using OrganicForm.Models;

namespace OrganicForm.Controllers
{
    public class OrderController : Controller
    {

        private readonly AppDbContext _dbContext;

        public OrderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get : Create Order
        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.Products.OrderBy(p=>p.ProductName).ToListAsync();
            ViewBag.Products = new SelectList(products, "Id", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveOrder([FromBody] List<OrderDetails> orderDetails)
        {
            if (orderDetails == null || !orderDetails.Any())
                return BadRequest(new { success = false, message = "No items to save." });

            //Server side vlaidation
            foreach (var item in orderDetails)
            {
                if (item.ProductId <= 0 || item.Quantity <= 0 || item.Unit<0 || item.Price < 0)
                    return BadRequest(new { success = false, message = "Invalid item data." });
            }

            var order = new Order { CreatedDate = DateTime.UtcNow };

            foreach (var item in orderDetails)
            {
                var details = new OrderDetails
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Unit = item.Unit,
                    Price = item.Price,
                };
                order.OrderDetails.Add(details);
            }
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return Ok(new { success = true, message = "Order saved", orderId = order.Id });
        }

        //Get: Fetch to View Orders Page
        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            //For dropdown
            var dates = await _dbContext.Orders
                .Select(o => o.CreatedDate.Date).Distinct().OrderByDescending(d => d).ToListAsync();
            
            ViewBag.Dates = new SelectList(
                dates.Select(d => new
                {
                   Value = d.ToString("yyyy-MM-dd"), 
                   Text = d.ToString("yyyy-MM-dd")   
                 }),
                "Value", "Text"
                 );
            return View("FetchView");
        }

        // GET: fetch orders by date (AJAX)
        [HttpGet]
        public async Task<JsonResult> GetOrdersByDate(DateTime date)
        {
            var data = await _dbContext.Orders
                .Where(o => o.CreatedDate.Date == date.Date)
                .SelectMany(o => o.OrderDetails)
                .Include(d => d.Products)
                .Select(d => new {
                    d.Id,
                    ProductName = d.Products.ProductName,
                    d.Quantity,
                    d.Unit,
                    d.Price
                })
                .ToListAsync();

            return Json(data);
        }



    }
}
