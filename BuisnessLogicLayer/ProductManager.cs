namespace BuisnessLogicLayer;
using DataAccessLayer;
using BuisnessObjectLayer;
using System.Collections.Generic;

public class ProductManager
{ 
    private ProductManager()
    {
        
    }

    public static ProductManager _ref = null;
    public static List <Product> products = DatabaseProductRepository.GetAllProducts();


    public static ProductManager GetProductManager(){
        if(_ref==null){
            _ref=new ProductManager();
        }
        return _ref;

    }

    public List<Product> GetAllProducts()
    {
        //System.Console.WriteLine("---------------------------------BLL------------------------");
        //Console.WriteLine(products.Count);
        return products;
    }

    public Product GetById(int id)
    {
        Product prod = DatabaseProductRepository.GetById(id);
        //Console.WriteLine(prod.Name);
        
        return prod;
    }

    /*public List<string> GetProductNames()
    {
        List<string> sortedProducts =(List<string>) from prod in products select prod.Name;
        System.Console.WriteLine("---------------------------------BLL------------------------");
        foreach(string name in sortedProducts)
            System.Console.WriteLine(name);
        return sortedProducts;
    }*/
}
