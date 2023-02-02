using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Models;
using ServiceAccessLayer;
using BuisnessObjectLayer;

namespace ShoppingApp.Controllers;

public class ProductsController : Controller
{
    //List <Product> products = new List<Product> ();
    private readonly ILogger<ProductsController> _logger;
    
    /*public void initialize()
    {
        products.Add(new Product{Id=1, Name="Pixel 7 pro", Screen="6.7", Camera="50MP", Image=@"\Images\google-pixel7-new.jpg", Ram=12, Price=80000});
        products.Add(new Product{Id=2, Name="Pixel 7", Screen="6.3", Camera="50MP", Image=@"\Images\google-pixel7-new.jpg", Ram=8, Price=60000});
        products.Add(new Product{Id=3, Name="Pixel 6 pro", Screen="6.7", Camera="50MP", Image=@"\Images\google-pixel-6-pro.jpg", Ram=12, Price=55000});
        products.Add(new Product{Id=4, Name="Pixel 6", Screen="6.7", Camera="50MP", Image=@"\Images\google-pixel-6.jpg", Ram=8, Price=40000});
        products.Add(new Product{Id=5, Name="Pixel 6a", Screen="6.7", Camera="12MP", Image=@"\Images\google-pixel-6a.jpg", Ram=6, Price=30000});
    }*/

    public ProductsController(ILogger<ProductsController> logger)
    { 
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Product> products = ProductService.GetAll();
        //System.Console.WriteLine("---------------------------------Controller------------------------");
        //Console.WriteLine(products.Count);
        ViewData["products"] = products;
        return View();
    }
    public IActionResult Details(int id)
    {
        //Console.WriteLine("Display method");
        //Console.WriteLine(id);
        //initialize();
        Product currentProduct = null;
        List<Product> products = ProductService.GetAll();
        foreach (Product prod in products)
        {
            if(prod.Id==id)
            {
                currentProduct = prod;
                ViewData["Product"] = currentProduct;
                break;
            }
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
