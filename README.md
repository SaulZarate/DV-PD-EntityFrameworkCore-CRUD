# CRUD con Entity Framework Core 

Proyecto realizado a modo de practica

## Creación del proyecto desde cero

* Installar los siguientes paquetes desde el administrador de paquetes NuGet: 
    * Microsoft.EntityFrameworkCore
    * Pomelo.EntityFrameworkCore.MySql
    * Microsoft.EntityFrameworkCore.Tools
* Crear una base de datos
    * Cambiar las credenciales de Helpers/Config.cs
* Crer una clase para el context
    * La clase debe heredar de DBContext
    * Importar EF Core en la clase
    ```
        using Microsoft.EntityFrameworkCore;
    ```
    * Crear el constructor (dejarlo vacío)
* Crear una clase por Modelo
    * Agregar los atributos necesarios usando properties
    ```
        public Tipo nombreAtributo { get; set; }
    ```
    * Agregar un atributo DbSet por cada Modelo
    ```
        public DbSet<Model> nombreAtributo { get; set; }
    ```
* Configuracion de las migraciones (dentro de la clase Context)
    * Crear un metodo para indicar el SGBD a usar
    ```
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(String connectionString, new MySqlServerVersion(new Version()));
        }
    ```
    * Crear un metodo para configurar las migraciones por defecto
    ```
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // Indico el nombre que va a tener un modelo en la DB. Se pueden hacer mas cosas
            modelBuilder.Entity<Model>().ToTable("nombreDeLaTabla");

            // Configuro las propiedades de la tabla. Se pueden hacer mas cosas
            // Ejemplo:
            modelBuilder.Entity<Categoria>(
                categoria =>
                {
                    categoria.Property(c => c.Nombre).HasColumnType("varchar(80)").IsRequired(true);
                });

            // Inserto 2 registros
            // Ejemplo:
            modelBuilder.Entity<Categoria>().HasData(new Categoria[]{
                new Categoria { nombreAtributo1 = valor, nombreAtributo2 = valor, ... },
                new Categoria { nombreAtributo1 = valor, nombreAtributo2 = valor, ... },
            });
        }
    ```
* Agrego las migraciones:
```
    EntityFrameworkCore\Add-Migration nombreDeLaMigracion
```
* "Ejecuto" las migraciones:
```
    EntityFrameworkCore\Update-Database
```

## Autor

- Saúl Zarate - Desarrollador

  
