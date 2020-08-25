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
    }
}