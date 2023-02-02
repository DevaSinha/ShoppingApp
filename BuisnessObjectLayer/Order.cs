namespace BuisnessObjectLayer;

public class Order
{
    public int Id{get; set;}
    public DateTime Date{get; set;}
    public double TotalPrice {get; set;}
    public List<Items> Items {get; set;}
}