using System.Collections.Generic;

namespace ShoppingOnline1.Models;

public interface IProductInterface
{
    Product GetProduct(int id);
    Product AddProduct(Product product);
    IEnumerable<Product> GetAllProducts();
    Product UpdateProduct(Product product);
    Product DeleteProduct(int id);
}