namespace BuisnessObjectLayer;


public class Product
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Screen {get; set;}
    public string Camera {get; set;}
    public int Ram {get; set;}
    public double Price {get; set;}
    public string Image{get; set;}

    public void Display()
    {
        Console.WriteLine(Name);
        Console.WriteLine("  Screen Size : "+Screen);
        Console.WriteLine("  Camera : "+Camera);
        Console.WriteLine("  Ram : "+Ram+" GB");
        Console.WriteLine("  Price : "+Price);
    }
}