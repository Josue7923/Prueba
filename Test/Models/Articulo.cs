using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Articulo
    {
        [Key]

        public int CodArticulo { get; set; }

        public string Nombre { get; set; }

        public int Precio { get; set; }

        public string Descripcion { get; set; }

    }
}
