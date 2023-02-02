namespace ShoppingApp.Models;
public class Customer
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string BirthDate {get; set;}
    public string Gender {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}

    public void Display()
    {
        Console.WriteLine(FirstName +" "+LastName+"\n"+BirthDate+" "+Gender+"\n"+Email+" "+Password);
    }
}