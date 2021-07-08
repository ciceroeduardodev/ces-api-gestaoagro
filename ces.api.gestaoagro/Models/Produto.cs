using System;
using System.Collections.Generic;

#nullable disable

namespace ces.api.gestaoagro.Models
{
    public partial class Produto
    {
        public int CliId { get; set; }
        public int PrdId { get; set; }
        public string PrdNome { get; set; }
        public int? PrdAtivo { get; set; }
    }
}
