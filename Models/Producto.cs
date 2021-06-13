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

        public List<String> ProductoToList()
        {
            return new List<string>()
            {
                this.Id.ToString(),
                this.Nombre,
                this.Precio.ToString(),
                this.Stock.ToString(),
                this.FechaDeCreacion.ToString(),
                this.Categoria_id.ToString()
            };
        }
    }
}
