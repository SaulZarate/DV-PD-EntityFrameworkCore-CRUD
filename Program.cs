using System;

using pruebasEntityFramework.Controllers;
using Microsoft.EntityFrameworkCore;

namespace pruebasEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicio del proyecto
            (new AppController()).Iniciar();
        }
    }
}
