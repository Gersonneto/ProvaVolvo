using Microsoft.EntityFrameworkCore;
using Volvo.Domain.Caminhoes;

namespace ProvaVolvo.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Caminhao> Caminhoes { get; set; }

    }
}