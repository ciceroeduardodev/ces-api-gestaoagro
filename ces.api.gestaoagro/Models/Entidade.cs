using System;
using System.Collections.Generic;

#nullable disable

namespace ces.api.gestaoagro.Models
{
    public partial class Entidade
    {
        public int CliId { get; set; }
        public int BalId { get; set; }
        public int EntId { get; set; }
        public string EntNome { get; set; }
        public string EntTipo { get; set; }
        public string EntCpfCnpj { get; set; }
        public string EntEmail { get; set; }
        public int? EntAtivo { get; set; }
    }
}
