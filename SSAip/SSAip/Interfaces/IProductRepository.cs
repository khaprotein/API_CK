using SSAip.DTO;
using SSAip.Models;

namespace SSAip.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetAll();
        Product GetProductByID(string id);
        ICollection<Product> GetProductByName(string name);
        ICollection<Product> GetProductByCategory(int id);
        ICollection<Product> GetProductByBrand(int id);

        string GetProductImage(string id);
        string GetProductName(string id);
        string GetProductDescription(string id);
        string GetProductDetail(string id);
        string GetProductID(string id);

        bool Add(ProductDTO product);
        bool Update(ProductDTO product);
        bool Delete(string id);
      
        


    }
}
