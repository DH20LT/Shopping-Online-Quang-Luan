using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline1.Models;
using ShoppingOnline1.Models.ViewModals;

namespace ShoppingOnline1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private IProductInterface _productInterface;

    private IWebHostEnvironment _webHost;

    public HomeController(ILogger<HomeController> logger,
        IWebHostEnvironment webHost, IProductInterface productInterface)
    {
        _logger = logger;
        _webHost = webHost;
        _productInterface = productInterface;
    }


}