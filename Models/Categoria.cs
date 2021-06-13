using System;
using System.Collections.Generic;
using System.Text;

namespace pruebasEntityFramework.Models
{
    class Categoria
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public List<String> CategoriaToList()
        {
            return new List<string>() { this.Id.ToString(), this.Nombre };
        }
    }
}
