using SSAip.Interfaces;
using SSAip.Models;

namespace SSAip.Repository
{
    public class CategoryRespository : ICategoryRepository
    {
        private readonly SHOESTOREContext _context;
        public CategoryRespository(SHOESTOREContext context) {
            _context = context;

        }
        public ICollection<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c=>c.CategoryId==id);
        }

        public string GetName(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id).CategoryName;
        }
    }
}
