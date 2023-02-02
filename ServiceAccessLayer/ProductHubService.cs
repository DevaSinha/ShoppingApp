namespace ServiceAccessLayer;
using BuisnessLogicLayer;
using BuisnessObjectLayer;
using System.Collections.Generic;

public static class ProductService
{

    static ProductManager manager=ProductManager.GetProductManager();


    public static List<Product> GetAll()
    {
        //ProductManager Manager=ProductManager.GetProductManager();
        List<Product> allProducts = manager.GetAllProducts();
        //System.Console.WriteLine("---------------------------------SAL------------------------");
        //Console.WriteLine(allProducts.Count);
        return allProducts;
    }

    /*public static List<String> GetName()
    {
        
        List<String> prod = manager.GetProductNames();
        System.Console.WriteLine("---------------------------------SAL------------------------");
        foreach(string name in prod)
            System.Console.WriteLine(name);
        return prod;
    }*/

    public static Product GetProductById(int id)
    {

        //Product prd=manager.GetById(id);
        
        return manager.GetById(id);
    }
}
