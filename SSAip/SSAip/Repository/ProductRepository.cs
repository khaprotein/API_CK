using SSAip.DTO;
using SSAip.Interfaces;
using SSAip.Models;

namespace SSAip.Repository
{
    public class ProductRepository : IProductRepository
    {
         private readonly SHOESTOREContext _context;
        public ProductRepository(SHOESTOREContext context) {
            _context = context;
        }

        public bool Add(ProductDTO product)
        {
            var newProduct = new Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductimageUrl = product.ProductimageUrl,
                Detail = product.Detail,
                Description = product.Description,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return true;
        }
        public bool Update(ProductDTO product)
        {
            var oldProduct = _context.Products.FirstOrDefault(c => c.ProductId == product.ProductId);
            if (oldProduct != null)
            {
                oldProduct.ProductName = product.ProductName;
                oldProduct.ProductimageUrl = product.ProductimageUrl;
                oldProduct.Detail = product.Detail;
                oldProduct.Description = product.Description;
                oldProduct.BrandId = product.BrandId;
                oldProduct.CategoryId = product.CategoryId;
                _context.SaveChanges();
                return true;
            }
             return false; 
           
        }

        public bool Delete(string id)
        {
            var product = _context.Products.FirstOrDefault(c=>c.ProductId==id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public ICollection<Product> GetProductByBrand(int id)
        {
            var list = _context.Products.Where(c=>c.BrandId== id).ToList();
            return list;
        }

        public ICollection<Product> GetProductByCategory(int id)
        {
            var list = _context.Products.Where(c => c.CategoryId == id).ToList();
            return list;
        }

        public Product GetProductByID(string id)
        {
            return _context.Products.FirstOrDefault(c => c.ProductId == id);
        }

        public ICollection<Product> GetProductByName(string name)
        {
            return _context.Products
                           .Where(c => c.ProductName.Contains(name))
                           .ToList();
        }

        public string GetProductDescription(string id)
        {
           return _context.Products.FirstOrDefault(c=>c.ProductId==id).Description;
        }

        public string GetProductDetail(string id)
        {
            return _context.Products.FirstOrDefault(c => c.ProductId == id).Detail;
        }

        public string GetProductID(string id)
        {
            return _context.Products.FirstOrDefault(c => c.ProductId == id).ProductId;
        }

        public string GetProductImage(string id)
        {
            return _context.Products.FirstOrDefault(c => c.ProductId == id).ProductimageUrl;
        }

        public string GetProductName(string id)
        {
            return _context.Products.FirstOrDefault(c => c.ProductId == id).ProductName;
        }

        
    }

}
