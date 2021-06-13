using System;
using System.Collections.Generic;
using System.Text;

namespace pruebasEntityFramework.Views
{
    class ConsoleView
    {
        public void mostrarMensaje(String mensaje = "")
        {
            Console.WriteLine(mensaje);
        }
        public String pedirDato(String mensaje = "")
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }
        public void imprimirCategorias(List<List<String>> categorias)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("------------ CATEGORIAS ------------");
            Console.WriteLine("------------------------------------");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"Id: {categoria[0]}");
                Console.WriteLine($"Nombre: {categoria[1]}" + "\n");
            }
        }
        public void imprimirProductos(List<List<String>> productos)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("------------ PRODUCTOS ------------");
            Console.WriteLine("-----------------------------------");
            foreach (var producto in productos)
            {
                Console.WriteLine($"Id: {producto[0]}");
                Console.WriteLine($"Nombre: {producto[1]}");
                Console.WriteLine($"Precio: {producto[2]}");
                Console.WriteLine($"Stock: {producto[3]}");
                Console.WriteLine($"Fecha de creación: {producto[4]}");
                Console.WriteLine($"Categoria: {producto[5]}" + "\n");
            }
        }

    }
}
