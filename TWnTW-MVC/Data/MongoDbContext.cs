using Microsoft.EntityFrameworkCore;
using TWnTW_MVC.Models;

namespace TWnTW_MVC.Data
{
    public class MongoDbContext : DbContext
    {
        public MongoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WorkSpace> WorkSpaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<MemberDetail> MemberDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkSpace>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<TaskDetail>();
            modelBuilder.Entity<MemberDetail>();
        }
    }
}
