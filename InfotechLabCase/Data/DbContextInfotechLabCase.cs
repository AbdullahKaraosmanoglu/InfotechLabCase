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

    }
}
