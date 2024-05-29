using AutoMapper;
using SSAip.DTO;
using SSAip.Models;

namespace SSAip.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Brand, BrandDTO>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<Cart, CartDTO>();
            CreateMap<Coupon, CouponDTO>();

            CreateMap<Inventory, InventoryDTO>();

            CreateMap<Product, ProductDTO>();   
            CreateMap<ProductReview,ProductReviewDTO>();
           
            CreateMap<Order,OrderDTO>();
            CreateMap<OrderDetail,OrderDetailDTO>();
            CreateMap<OrderStatus,OrderStatusDTO>();
            CreateMap<OrdersCoupon,OrdersCouponDTO>();

            CreateMap<User, UserDTO>();
            CreateMap<Role, RoleDTO>();
        }
    }
}
