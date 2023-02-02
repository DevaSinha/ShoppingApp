namespace DataAccessLayer;
using BuisnessObjectLayer;
using MySql.Data.MySqlClient;
public static class DatabaseProductRepository
{
    public static string connstr= "Server=localhost;port=3306;Database=dotnet;Uid=root;Pwd=deva1703;";
    public static List<Product> GetAllProducts()

    {
        List<Product> products = new List<Product>();
        using(MySqlConnection con = new MySqlConnection(connstr))
        {
            con.Open();
            using(MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "select * from products";
                cmd.Connection = con;
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["productId"].ToString());
                        string name = reader["productName"].ToString();
                        string screen = reader["Screen"].ToString();
                        string camera = reader["Camera"].ToString();
                        int ram = int.Parse(reader["Ram"].ToString());
                        double price = double.Parse(reader["Price"].ToString());
                        string image = reader["Image"].ToString();
                        products.Add(new Product{Id=id, Name=name, Screen=screen, Camera=camera, Ram=ram, Price=price, Image=image});
                    }
                }
            }
        }
        return products;
    }

    public static Product GetById(int id)
    {
        Product requiredProduct = new Product();

        using(MySqlConnection conn = new MySqlConnection(connstr))
        {
            conn.Open();
            using(MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select * from products where productId =@id";
                cmd.Parameters.AddWithValue("@id", id);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        requiredProduct.Id = int.Parse(reader["productId"].ToString());
                        requiredProduct.Name = reader["productName"].ToString();
                        requiredProduct.Screen = reader["Screen"].ToString();
                        requiredProduct.Camera = reader["Camera"].ToString();
                        requiredProduct.Ram = int.Parse(reader["Ram"].ToString());
                        requiredProduct.Price = double.Parse(reader["Price"].ToString());
                        requiredProduct.Image = reader["Image"].ToString();
                    }
                }
            }
        }
        //requiredProduct.Display();
        return requiredProduct;
    }
}