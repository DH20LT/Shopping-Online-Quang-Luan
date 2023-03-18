using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingOnline1.Models.Carts;
using ShoppingOnline1.Models.Orders;

namespace ShoppingOnline1.Controllers;

public class OrderController : Controller
{
    private ILogger<OrderController> _logger;

    private readonly IOrderRepository _orderRepository;

    private Cart _cart;

    public OrderController(IOrderRepository orderRepository, Cart cartService, ILogger<OrderController> logger)
    {
        _orderRepository = orderRepository;
        _cart = cartService;
        _logger = logger;
    }

    // GET
    [HttpGet]
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (_cart.Items.Count() == 0)
        {
            ModelState.AddModelError("", "Sorry, your cart is empty!");
            _logger.LogWarning("Checkout failed: cart is empty");
        }

        if (ModelState.IsValid)
        {
            _orderRepository.SaveOrder(order);
            return RedirectToAction("Completed");
        }
        else
        {
            return View(order);
        }
    }

    public ViewResult Completed()
    {
        _cart.Clear();
        return View();
    }
}
