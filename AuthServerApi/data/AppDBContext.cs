using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace AuthserverAPi.data{
   public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options){
        }

        public DbSet<Login> Users{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
        }
    }
}