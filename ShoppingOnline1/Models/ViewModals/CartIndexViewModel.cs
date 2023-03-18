using ShoppingOnline1.Models.Carts;

namespace ShoppingOnline1.Models.ViewModals;

public class CartIndexViewModel
{
    public Cart Cart { get; set; }

    public string ReturnUrl { get; set; }
}