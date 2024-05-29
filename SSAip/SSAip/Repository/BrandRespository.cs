using SSAip.Interfaces;
using SSAip.Models;

namespace SSAip.Repository
{
    public class BrandRespository : IBrandRepository
    {
        private readonly SHOESTOREContext _context;
        public BrandRespository(SHOESTOREContext context)
        {
            _context = context;
        }
        public Brand FindById(int id)
        {
            return _context.Brands.FirstOrDefault(c => c.BrandId == id);
        }

        public ICollection<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }

        public string GetBrandName(int id)
        {
            var namebrand = _context.Brands.FirstOrDefault(b => b.BrandId == id);
            return namebrand.BrandName;
        }
    }
}
