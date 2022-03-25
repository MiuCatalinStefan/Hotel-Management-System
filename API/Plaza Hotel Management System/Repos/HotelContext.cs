using Microsoft.EntityFrameworkCore;
using Plaza_Hotel_Management_System.Models;

namespace Plaza_Hotel_Management_System.Repos
{
    public class HotelContext : DbContext
    {
        // Aici unim Entity FrameWork-ul de Baza de Date din MSSQL
        public HotelContext(DbContextOptions<HotelContext> opt) : base(opt)
        {

        }
        
        public DbSet<Client> Clienti { get; set; }

        public DbSet<Rezervare> Rezervari { get; set; }

        public DbSet<Camera> Camere { get; set; }
    }
}
