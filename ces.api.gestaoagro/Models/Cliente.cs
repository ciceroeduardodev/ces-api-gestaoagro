using System;
using System.Collections.Generic;

#nullable disable

namespace ces.api.gestaoagro.Models
{
    public partial class Cliente
    {
        public int CliId { get; set; }
        public string CliNome { get; set; }
        public string CliToken { get; set; }
        public DateTime? CliData { get; set; }
        public int? CliAtivo { get; set; }
    }
}
