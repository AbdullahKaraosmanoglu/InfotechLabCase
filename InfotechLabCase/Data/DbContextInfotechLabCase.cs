using InfotechLabCase.Models;
using Microsoft.EntityFrameworkCore;

namespace InfotechLabCase.Data
{
    public class DbContextInfotechLabCase : DbContext
    {
        public DbContextInfotechLabCase(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AdminModel> TblAdmin { get; set; }
        public DbSet<ExpertModel> TblExpert { get; set; }
        public DbSet<CustomerModel> TblCustomer { get; set; }
        public DbSet<OfferModel> TblOffer { get; set; }
        public DbSet<ServiceCategoryModel> TblServiceCategory { get; set; }
        public DbSet<UserModel> TblUser { get; set; }
        public DbSet<RoleModel> TblRole { get; set; }
        public DbSet<CityModel> TblCity { get; set; }
        public DbSet<DistrictModel> TblDistrict { get; set; }
        public DbSet<NeighbourhoodModel> TblNeighbourhood { get; set; }
        public DbSet<ExpertCommentModel> TblExpertComment { get; set; }
        
    }
}
