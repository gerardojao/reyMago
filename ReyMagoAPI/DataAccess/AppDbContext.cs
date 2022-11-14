using Microsoft.EntityFrameworkCore;
using ReyMagoApi.Entities;
using ReyMagoAPI.DataAccess;
using ReyMagoAPI.Entities;

namespace ReyMagoApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<SolicitudIngreso> SolicitudIngresos { get; set; }
        public DbSet<Afinidad> Afinidades { get; set;}
        public DbSet<Grimorio> Grimorios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var foreingKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                foreingKey.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);

            builder.Seed();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        //public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess)
        //{
        //    return await base.SaveChangesAsync(acceptAllChangesOnSuccess);
        //}
    }
}
