using System;
using System.Collections.Generic;
using System.Text;

namespace pruebasEntityFramework.Models
{
    class Producto
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public double Precio{ get; set; }
        public int Stock{ get; set; }
        public DateTime FechaDeCreacion{ get; set; }
        public int Categoria_id { get; set; }

    }
}
