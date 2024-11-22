using BuscaPersonalApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuscaPersonalApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<AcademiaEntity> Academia { get; set; }
        public DbSet<PersonalEntity> Personal { get; set; }
        public DbSet<AcademiaPersonalEntity> AcademiaPersonal { get; set; }
    }
}
