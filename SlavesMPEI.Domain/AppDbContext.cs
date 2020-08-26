using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using SlavesMPEI.Domain.Entities;

namespace SlavesMPEI.Domain
{
    public class AppDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Все заказы
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=88.135.50.215,1433; Initial Catalog=SlavesMPEIdb; User ID=Misha; Password=789xxx44XX; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False;"
                ,b => b.MigrationsAssembly("SlavesMPEI.Domain"));
        }
    }
}