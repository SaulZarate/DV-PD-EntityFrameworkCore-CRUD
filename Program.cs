using System;

using pruebasEntityFramework.Controllers;
using Microsoft.EntityFrameworkCore;

namespace pruebasEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                ------------------------------------------------------------
                ---------------------- REQUERIMIENTOS ----------------------
                ------------------------------------------------------------

                INSTALAR PAQUETES
                - Microsoft.EntityFrameworkCore
                - Pomelo.EntityFrameworkCore.MySql
                - Microsoft.EntityFrameworkCore.Tools
                

                BASE DE DATOS
                - Crear una base de datos 
                - Cambiar las credenciales en el archivo Helpers/Config.cs
            

                MODELOS
                - Crear una clase por entidad en la DB
                - Agregar un atributo a la clase context por Modelo
                            DbSet<TuModelo> NombreDelATributoEnPlural { get; set; }


                CONFIGURACION DE LAS MIGRACIONES
                - Modificar migraciones por defecto en la clase del Contexto:
                            - Agregar el metodo protected override void OnModelCreating(ModelBuilder modelBuilder)
                            - Modificar las migraciones a su gusto
                            - Tambien se pueden agregar datos por defecto si lo desea en este metodo

                MIGRACIONES
                - Agregar:
                            EntityFrameworkCore\Add-Migration nombreDeLaMigracion
                - Ejecutar migraciones agregadas:
                            EntityFrameworkCore\Update-Database
                - Eliminar todas migraciones:
                            EntityFrameworkCore\remove-migration -force
                - Listar migraciones:
                            Get-Migration
             */

            // Iniciar pruebas
            (new AppController()).Iniciar();
            
        }
    }
}
