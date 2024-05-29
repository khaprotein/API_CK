using SSAip.Models;

namespace SSAip.Interfaces
{
    public interface ICupRepository
    {
        ICollection<Coupon> GetAll();
        Coupon GetById(string id);
        string GetCouponCode(string id);
        
    }
}
