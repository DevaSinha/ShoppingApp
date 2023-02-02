namespace DataAccessLayer;
using BuisnessObjectLayer;
using System.Text.Json;
public static class ProductRepository
{
    public static List <Product> products;
    public static void Initialize ()
    {
        string restoredJsonString=File.ReadAllText(@"..\BuisnessObjectLayer\EntityFiles\products.json");
        products=JsonSerializer.Deserialize<List<Product>>(restoredJsonString);
    }
    public static List <Product> GetAll()
    {
        Initialize();
        Console.WriteLine("\n\n\n Deserialized data from file  products.json\n\n\n");
        //System.Console.WriteLine("---------------------------------Controller------------------------");
        //Console.WriteLine(products.Count);
        return products;
    }

    public static Product GetById(int id)
    {
        Product product = null;
        foreach(Product prod in products)
        {
            if (prod.Id == id)
                product = prod;
        }
        return product;
    }

    public static bool Insert (Product product)
    {
        int orgcount =products.Count;
        products.Add(product);
        int newcount = products.Count;
        if(orgcount != newcount)
            return true;
        else return false;

    }

    /*public static bool Delete (Product product)
    {
        if(products.Add(product))
            return true;
        else return false;

    }*/
}
