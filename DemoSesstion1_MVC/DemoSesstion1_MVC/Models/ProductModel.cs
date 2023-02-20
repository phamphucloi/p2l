namespace DemoSesstion1_MVC.Models;

public class ProductModel
{
    private List<Product> products;

    public ProductModel() {
        products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Phạm Phúc Lợi",
                Photo = "327308453_917558602598567_2671577435100712797_n.jpg",
                Price = 3.5,
                Qty = 3,
                Created = DateTime.Now
            },
            new Product
            {
                Id = 2,
                Name = "HULa",
                Photo = "327308453_917558602598567_2671577435100712797_n.jpg",
                Price = 5,
                Qty = 3,
                Created = DateTime.Now
            },
            new Product
            {
                Id = 3,
                Name = "kilo",
                Photo = "ppl.jpg",
                Price = 10,
                Qty = 3,
                Created = DateTime.Now
            }
        };
    }

    public List<Product> findAll() 
    {
        return products;
    }

    public Product Details(int id)
    {

        return products.SingleOrDefault(pro=>pro.Id==id);
    }

    public List<Product> SearchByKeyword(string keyword)
    {
        return products.Where(pro => pro.Name.Contains(keyword)).ToList();
    }

    public List<Product> SearchByPrice(double min, double max)
    {
        return products.Where(pro => pro.Price >= min && pro.Price <= max).ToList();
    }
}
