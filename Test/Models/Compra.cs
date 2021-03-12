using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Compra
    {
        [Key]

        public int CodCompra { get; set; }

        public int CodCliente { get; set; }
        public int CodArticulo { get; set; }
        public int MontoCancelado { get; set; }
        public int Cantidad { get; set; }

    }
}
