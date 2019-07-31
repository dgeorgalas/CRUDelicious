using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class MyContext : DbContext
    {
        //base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) {}
        
        //"dishes" table is represented by this DbSet "Dishes"
        public DbSet<Dish> Dishes {get; set;}
    }
}