using Microsoft.EntityFrameworkCore;
using TWnTW_MVC.Models;

namespace TWnTW_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WorkSpace> WorkSpaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<MemberDetail> MemberDetails { get; set; }
    }
}
