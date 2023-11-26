using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MICLifePortal.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BenefeciaryType> BenefeciaryTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContractorType> ContractorTypes { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<Reasons> Reasons { get; set; }
        public DbSet<ReasonsCategory> ReasonsCategories { get; set; }
        public DbSet<ReasonsType> ReasonsTypes { get; set; }
        public DbSet<RejectedEntity> RejectedEntities { get; set; }
        public DbSet<RejectionBeneficiary> RejectionBeneficiaries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TokenResponse> TokenResponses { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
