using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using pruebasEntityFramework.Helpers;

namespace pruebasEntityFramework.Models
{
    class MyContext: DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public MyContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.GetConnectionString(), new MySqlServerVersion(new Version()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* PRIMER MIGRACION */
            // Estructura de las tablas
            modelBuilder.Entity<Producto>().ToTable("PRODUCTOS");
            modelBuilder.Entity<Categoria>(
                categoria =>
                {
                    categoria.Property(c => c.Nombre).HasColumnType("varchar(80)").IsRequired(true);
                });

            modelBuilder.Entity<Categoria>().ToTable("CATEGORIAS");
            modelBuilder.Entity<Producto>(
                producto =>
                {
                    producto.Property( p => p.Nombre).HasColumnType("varchar(80)").IsRequired(true);
                });

            /* SEGUNDA MIGRACION */
            //// Agrego categorias
            //modelBuilder.Entity<Categoria>().HasData(new Categoria[]{
            //    new Categoria {Id=1, Nombre = "Remera" },
            //    new Categoria {Id=2, Nombre = "Pantalon" },
            //    new Categoria {Id=3, Nombre = "Campera" },
            //    new Categoria {Id=4, Nombre = "Calzado" },
            //});
            //// Agrego productos
            //modelBuilder.Entity<Producto>().HasData(new Producto[]{
            //    new Producto{ Id = 1, Nombre = "Remera manga larga rallada", Precio = 1200, Stock = 13, FechaDeCreacion = DateTime.Now, Categoria_id = 1},
            //    new Producto{ Id = 2, Nombre = "Remera manga corta estampada", Precio = 1450, Stock = 11, FechaDeCreacion = DateTime.Now, Categoria_id = 1},
                                     
            //    new Producto{ Id = 3, Nombre = "Pantalon chino color mostaza", Precio = 4100, Stock = 11, FechaDeCreacion = DateTime.Now, Categoria_id = 2},
            //    new Producto{ Id = 4, Nombre = "Pantalon Jean negro", Precio = 3800, Stock = 15, FechaDeCreacion = DateTime.Now, Categoria_id = 2},
            //    new Producto{ Id = 5, Nombre = "Bermuda color azul", Precio = 1100, Stock = 13, FechaDeCreacion = DateTime.Now, Categoria_id = 2},
                                     
            //    new Producto{ Id = 6, Nombre = "Campera parka", Precio = 12500, Stock = 4, FechaDeCreacion = DateTime.Now, Categoria_id = 3},
                                     
            //    new Producto{ Id = 7, Nombre = "Zapatilla blanca", Precio = 5800, Stock = 10, FechaDeCreacion = DateTime.Now, Categoria_id = 4},
            //});

        }
    }
}
