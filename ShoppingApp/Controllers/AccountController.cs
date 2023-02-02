using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers;

public class AccountController : Controller
{
    static List<Customer> customers = new List <Customer> ();

    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        //Console.WriteLine("In Post Method of Account Login");
        //Console.WriteLine(email + " "+password);
        foreach(Customer cs in customers)
        {
            if (cs.Email == email)
            {
                if(cs.Password == password)
                    Response.Redirect("/order/index");
            }
        }
        return View();
    }
    [HttpPost]
    public IActionResult Register(string firstName, string lastname, string birthdate, string gender, string email, string password)
    {
        //Console.WriteLine("In Post Method of Account Register");
        //Console.WriteLine(firstName+" "+lastname+" "+email);
        customers.Add(new Customer{FirstName = firstName, LastName=lastname, BirthDate=birthdate, Gender=gender, Email=email, Password=password});
        return this.RedirectToAction("Login","Account");
    }
    [HttpGet]
    public IActionResult Login()
    {
        //Console.WriteLine("In Get Method of Account Login");
        return View();
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        //Console.WriteLine("In Get Method of Product Register");
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
