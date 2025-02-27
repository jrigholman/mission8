using Microsoft.EntityFrameworkCore;

namespace Mission08_Group.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskAppModel> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            // Seed Initial Tasks 
            modelBuilder.Entity<TaskAppModel>().HasData(
                new TaskAppModel
                {
                    TaskId = 1,
                    TaskName = "Buy groceries",
                    DueDate = DateTime.Now.AddDays(2),
                    Quadrant = QuadrantType.II,
                    CategoryId = 1,
                    Completed = false
                }
            );
        }
    }
}