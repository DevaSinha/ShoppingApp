using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Models;
using ServiceAccessLayer;
using BuisnessObjectLayer;
using System.Text.Json;

namespace ShoppingApp.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;

    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //Console.WriteLine("Index");
        //int cart = 0;
        //if(HttpContext.Session.GetInt32("cart") != 0)
        string cart = HttpContext.Session.GetString("cart").ToString();
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(cart);
        //Console.WriteLine("Cart Id =" +cart);


        //Product product = ProductService.GetProductById(cart);
        //product.Display();
        this.ViewData["cart"] = products;
        return View();
    }

    public IActionResult AddToCart(int id)
    {
        List<Product> products;
        if (HttpContext.Session.GetString("cart") == null)
        {
            products = new List<Product>();
        }
        else
        {
            String data = HttpContext.Session.GetString("cart").ToString();
            products = JsonSerializer.Deserialize<List<Product>>(data);
        }
        products.Add(ProductService.GetProductById(id));
        string jsonString = JsonSerializer.Serialize(products);
        //Console.WriteLine("Add To Cart"); 
        HttpContext.Session.SetString("cart", jsonString);
        return RedirectToAction("Index", "Cart");
    }

    public IActionResult RemoveFromCart(int id)
    {
        Console.WriteLine("Remove");
        String data = HttpContext.Session.GetString("cart").ToString();
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(data);
        Product deleteProduct = products.Single(r => r.Id == id);
        products.Remove(deleteProduct);
        string jsonString = JsonSerializer.Serialize(products);
        HttpContext.Session.SetString("cart", jsonString);
        return RedirectToAction("Index", "Cart");

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
