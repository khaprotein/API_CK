using SSAip.Models;

namespace SSAip.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetAll();
        Category GetById(int id);
        string GetName(int id);
    }
}
