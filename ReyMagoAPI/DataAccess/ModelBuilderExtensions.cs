using Microsoft.EntityFrameworkCore;
using ReyMagoApi.Entities;

namespace ReyMagoAPI.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afinidad>()
                .HasData(
                        new Afinidad {Id = 1, Name = "Oscuridad"},
                        new Afinidad {Id = 2, Name = "Luz"},
                        new Afinidad {Id = 3,  Name = "Fuego"},
                        new Afinidad {Id = 4, Name = "Agua"},
                        new Afinidad {Id = 5,Name = "Viento",},
                        new Afinidad {Id = 6, Name = "Tierra"}
                        );
            modelBuilder.Entity<Grimorio>()
                .HasData(
                    new Grimorio
                    {
                        Id = 1,
                        Name = "Sinceridad",
                        Description = "Trébol de 1 hoja"
                    },
                    new Grimorio
                    {
                        Id = 2,
                        Name = "Esperanza",
                        Description = "Trébol de 2 hoja"
                    },
                    new Grimorio
                    {
                        Id = 3,
                        Name = "Amor",
                        Description = "Trébol de 3 hoja"
                    },
                    new Grimorio
                    {
                        Id = 4,
                        Name = "Buena Fortuna",
                        Description = "Trébol de 4 hoja"
                    },
                    new Grimorio
                    {
                        Id = 5,
                        Name = "Desesperación",
                        Description = "Trébol de 5 hoja"
                    }
                );
           
        }
    }
}
