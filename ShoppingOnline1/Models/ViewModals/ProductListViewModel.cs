namespace ShoppingOnline1.Models.ViewModals;

public class ProductListViewModel
{
    public IEnumerable<Product> Products { get; set; }

    public string CurrentCategory { get; set; }
}
