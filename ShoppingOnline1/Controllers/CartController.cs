﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingOnline1.Infrastructure;
using ShoppingOnline1.Models;
using ShoppingOnline1.Models.Carts;
using ShoppingOnline1.Models.ViewModals;

namespace ShoppingOnline1.Controllers;

public class CartController : Controller
{
    private readonly IProductInterface _productRepository;
    private ILogger<CartController> _logger;

    public CartController(IProductInterface productRepository, ILogger<CartController> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    // GET
    public ViewResult Index(string returnUrl)
    {
        return View(new CartIndexViewModel
        {
            Cart = GetCart(),
            ReturnUrl = returnUrl
        });
    }

    public RedirectToActionResult AddToCart(int id, string returnUrl)
    {
        Product product = _productRepository.GetAllProducts().FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            Cart cart = GetCart();
            cart.AddItem(product, 1);
            SaveCart(cart);
        }

        return RedirectToAction("Index", new { returnUrl });
    }

    public RedirectToActionResult RemoveFromCart(int id, string returnUrl)
    {
        Product product = _productRepository.GetAllProducts().FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            Cart cart = GetCart();
            cart.RemoveItem(product);
            SaveCart(cart);
        }

        return RedirectToAction("Index", new { returnUrl });
    }

    public RedirectToActionResult Clear(string returnUrl)
    {
        Cart cart = GetCart();
        cart.Clear();
        SaveCart(cart);
        return RedirectToAction("Index", new { returnUrl });
    }

    private Cart GetCart()
    {
        Cart cart = HttpContext.Session.GetJson<Cart>("Cart");
        if (cart == null)
        {
            cart = new Cart();
            SaveCart(cart);
        }
        return cart;
    }

    private void SaveCart(Cart cart)
    {
        HttpContext.Session.SetJson("Cart", cart);
    }
}
