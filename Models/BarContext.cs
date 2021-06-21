using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class BarContext : DbContext
    {

        public DbSet<LetnjiBar> Barovi {get; set;}  //referenca na podatke koje je nas model pokupio iz baze podataka
        public DbSet<Lezaljka> Lezaljke {get; set;} 
        public DbSet<Porudzbina> Porudzbine {get; set;} 

        public BarContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}