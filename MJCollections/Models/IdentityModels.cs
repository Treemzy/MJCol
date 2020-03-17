using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MJCollections.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<MJCollections.Models.Sales> Sales { get; set; }

        public System.Data.Entity.DbSet<MJCollections.Models.Pictures> Pictures { get; set; }

        public System.Data.Entity.DbSet<MJCollections.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<MJCollections.Models.ProductType> ProductTypes { get; set; }

        //public System.Data.Entity.DbSet<MJCollections.Models.SalesDetail> SalesDetails { get; set; }

        public System.Data.Entity.DbSet<MJCollections.Models.StockBalance> StockBalances { get; set; }

        public System.Data.Entity.DbSet<MJCollections.Models.Supply> Supplies { get; set; }

        public System.Data.Entity.DbSet<MJCollections.Models.Order> Orders { get; set; }
    }
}