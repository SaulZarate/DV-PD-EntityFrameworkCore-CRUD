using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using pruebasEntityFramework.Models;
using pruebasEntityFramework.Views;

namespace pruebasEntityFramework.Controllers
{
    class AppController
    {
        private DbSet<Categoria> categorias;
        private DbSet<Producto> productos;

        private ConsoleView vista;
        private MyContext context;

        public AppController()
        {
            inicializarAtributos();
        }
        private void inicializarAtributos()
        {
            try
            {
                // Creo una vista
                this.vista = new ConsoleView();

                // Guardo el contexto
                this.context = new MyContext();

                // Cargo los datos de la DB
                this.context.Categorias.Load();
                this.context.Productos.Load();

                // Guardarlos como atributos
                this.categorias = this.context.Categorias;
                this.productos = this.context.Productos;
            }
            catch (Exception)
            {
                // Exception
            }
        }

        public void Iniciar()
        {
            // Verifico que todo funciones bien
            //this.vista.mostrarMensaje("Hola Mundo!");

            //this.listarTodo();
            //this.listarCategorias();
            // Ordenado por nombre de categoria
            //this.listarProductosOrdenadosPorCategoria();
            // Ordenado por categoria_id
            //this.listarProductosOrdenadosPorCategoria(true);

            /* AGREGAR CATEGORIA */
            //this.listarCategorias();
            //if (this.agregarCategoria()) this.vista.mostrarMensaje("\n---- Categoria agregada ----\n");
            //else this.vista.mostrarMensaje("\n---- No se pudo agregar la categoria ----\n");
            //this.listarCategorias();

            /* AGREGAR PRODUCTO */
            //this.listarProductos();
            //// Agregar producto
            //if (this.agregarProducto()) this.vista.mostrarMensaje("\n---- Producto agregado ----\n");
            //Thread.Sleep(2500);
            //this.listarProductos();

            /* ELIMINAR CATEGORIA */
            //this.listarCategorias();
            //if (this.eliminarCategoria()) this.vista.mostrarMensaje("\n---- Categoria eliminada----\n");
            //Thread.Sleep(2500);
            //this.listarCategorias();

            /* EDITAR CATEGORIA (Harcodeada) */
            this.listarCategorias();
            if (this.editarCategoria()) this.vista.mostrarMensaje("\n---- Categoria editada ----\n");
            Thread.Sleep(2500);
            this.listarCategorias();

            // Para no cortar la App
            this.vista.pedirDato();
        }
        private void listarTodo()
        {
            this.vista.mostrarMensaje("-------- CATEGORIAS --------");
            foreach (var categoria in this.categorias)
                this.vista.mostrarMensaje($"Id: {categoria.Id} - Nombre: {categoria.Nombre}");
            this.vista.mostrarMensaje();

            this.vista.mostrarMensaje("-------- PRODUCTOS --------");
            foreach (var producto in this.productos)
            {
                this.vista.mostrarMensaje($"Id: {producto.Id}");
                this.vista.mostrarMensaje($"Nombre: {producto.Nombre}");
                this.vista.mostrarMensaje($"Precio: {producto.Precio}");
                this.vista.mostrarMensaje($"Stock: {producto.Stock}");
                this.vista.mostrarMensaje($"Fecha de creacion: {producto.FechaDeCreacion.ToString()}");
                // this.vista.mostrarMensaje($"Categoria_id: {producto.Categoria_id}");
                var categoriaDelProducto = this.categorias.Find(producto.Categoria_id);
                this.vista.mostrarMensaje($"Categoria: {categoriaDelProducto.Nombre}");
                // Salto de linea
                this.vista.mostrarMensaje();
            }
        }
        private void listarCategorias()
        {
            this.vista.mostrarMensaje("--------- CATEGORIAS ---------");
            //foreach (var categoria in this.categorias)
            //{
            //    this.vista.mostrarMensaje($"Id: {categoria.Id}");
            //    this.vista.mostrarMensaje($"Nombre: {categoria.Nombre}" + "\n");
            //}

            // Consulta SIN TRACKING. Trae los datos directamente de la DB
            //foreach(var categoria in this.categorias.AsNoTracking().ToList())
            //{
            //    this.vista.mostrarMensaje($"Id: {categoria.Id}");
            //    this.vista.mostrarMensaje($"Nombre: {categoria.Nombre}" + "\n");
            //}

        }
        private void listarProductos()
        {
            var productos = from p in this.productos
                        join c in this.categorias
                            on p.Categoria_id equals c.Id
                        select new { p.Id, p.Nombre, p.Precio, p.Stock, p.FechaDeCreacion, Categoria = c.Nombre };
            
            this.vista.mostrarMensaje("--------- PRODUCTOS ---------");
            foreach (var producto in productos)
            {
                this.vista.mostrarMensaje($"Id: {producto.Id}");
                this.vista.mostrarMensaje($"Nombre: {producto.Nombre}");
                this.vista.mostrarMensaje($"Precio: {producto.Precio}");
                this.vista.mostrarMensaje($"Stock: {producto.Stock}");
                this.vista.mostrarMensaje($"Fecha de creacion: {producto.FechaDeCreacion.ToString()}");
                this.vista.mostrarMensaje($"Categoria: {producto.Categoria}" + "\n");
            }
}
        private void listarProductosOrdenadosPorCategoria(Boolean orderForCategoria_id = false)
        {
            /* JOIN CON LINQ Y LAMBDA */
            var productos = this.productos.
                                        Join(this.categorias,
                                            producto => producto.Categoria_id,
                                            categoria => categoria.Id,
                                            (producto, categoria) =>
                                            new
                                            {
                                                Id = producto.Id,
                                                Nombre = producto.Nombre,
                                                Precio = producto.Precio,
                                                Stock = producto.Stock,
                                                FechaDeCreacion = producto.FechaDeCreacion,
                                                Categoria = categoria.Nombre
                                                // Categoria_id = categoria.Id
                                            })
                                        .OrderBy(p => p.Categoria)
                                        // .OrderBy( p => p.Categoria_id); 
                                        .Select( p => p);

            if (orderForCategoria_id)
            {
                /* JOIN CON LINQ */
                productos = from p in this.productos
                            join c in this.categorias
                                on p.Categoria_id equals c.Id
                            orderby c.Id
                            //orderby c.Nombre
                            select new { p.Id, p.Nombre, p.Precio, p.Stock, p.FechaDeCreacion, Categoria = c.Nombre };
            }

            this.vista.mostrarMensaje("-------- PRODUCTOS --------");
            foreach (var producto in productos)
            {
                this.vista.mostrarMensaje($"Id: {producto.Id}");
                this.vista.mostrarMensaje($"Nombre: {producto.Nombre}");
                this.vista.mostrarMensaje($"Precio: {producto.Precio}");
                this.vista.mostrarMensaje($"Stock: {producto.Stock}");
                this.vista.mostrarMensaje($"Fecha de creacion: {producto.FechaDeCreacion.ToString()}");
                this.vista.mostrarMensaje($"Categoria: {producto.Categoria}" + "\n");
            }
        }

        private bool agregarCategoria()
        {
            String nombre = this.vista.pedirDato("Ingrese el nombre de la categoria: ");
            this.categorias.Add(new Categoria { Nombre = nombre});
            return this.context.SaveChanges() == 1 ? true : false;
        }
        private bool agregarProducto()
        {
            String nombre = this.vista.pedirDato("Ingrese el nombre: ");
            double precio = double.Parse(this.vista.pedirDato("Ingrese el precio: "));
            int stock = Int32.Parse(this.vista.pedirDato("Ingrese el stock: "));
            DateTime fechaDeCreacion = DateTime.Now;
            int categoria_id = Int32.Parse(this.vista.pedirDato("Ingrese la categoria id: "));

            if (this.categorias.Find(categoria_id) == null)
            {
                this.vista.mostrarMensaje("\n---- Su categoria id no existe ----\n");
                return false;
            }

            this.productos.Add(new Producto {Nombre = nombre, Precio = precio, Stock = stock,FechaDeCreacion = fechaDeCreacion, Categoria_id = categoria_id });

            if (this.context.SaveChanges() == 1)
                return true;
            else
                this.vista.mostrarMensaje("\n---- No se pudo guardar ----\n");
                return false;
        }
        private bool eliminarCategoria()
        {
            int categoria_id = Int32.Parse(this.vista.pedirDato("Id de categoria: "));
            Categoria categoria = this.categorias.Find(categoria_id);

            if ( categoria == null)
            {
                this.vista.mostrarMensaje("\n---- No existe ese id ----\n ");
                return false;
            }

            this.categorias.Remove(categoria);
            if(this.context.SaveChanges() == 1)
                return true;
            else
            {
                this.vista.mostrarMensaje("\n---- No existe ese id ----\n");
                return false;
            }
            
        }
        private bool editarCategoria()
        {
            int categoria_id = 7;
            String nuevoNombreDeCategoria = "CategoriaHarcodeada2";

            Categoria categoria = this.categorias.Find(categoria_id);
            if (categoria == null)
            {
                this.vista.mostrarMensaje("\n---- No existe ese id ----\n ");
                return false;
            }
            
            categoria.Nombre = nuevoNombreDeCategoria;
            this.categorias.Update(categoria);

            if (this.context.SaveChanges() == 1) return true;
            else
            {
                this.vista.mostrarMensaje("\n---- No se pudo guardar el cambio ----\n ");
                return false;
            }
        }

    }
}
