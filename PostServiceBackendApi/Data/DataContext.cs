using Microsoft.EntityFrameworkCore;
using PostServiceBackendApi.Entities;

namespace PostServiceBackendApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Post>()
        //        .HasMany(b => b.Parcels)
        //        .WithOne()
        //        .HasForeignKey(h => h.PostId);
        //}
    }
}
