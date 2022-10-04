using DesafioAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace DesafioAPI.Context
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> opt) :
            base(opt)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }

        
    }
}
