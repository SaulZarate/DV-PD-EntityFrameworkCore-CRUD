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

    }
}
