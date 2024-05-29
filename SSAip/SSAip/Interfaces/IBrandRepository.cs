using SSAip.Models;

namespace SSAip.Interfaces
{
    public interface IBrandRepository
    {
        ICollection<Brand> GetAll();
        Brand FindById(int id);

        string GetBrandName(int id);

    }
}
