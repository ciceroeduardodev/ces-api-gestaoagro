using System;
using System.Collections.Generic;

#nullable disable

namespace ces.api.gestaoagro.Models
{
    public partial class Usuario
    {
        public int CliId { get; set; }
        public int UsrId { get; set; }
        public string UsrAlias { get; set; }
        public string UsrNome { get; set; }
        public string UsrEmail { get; set; }
        public string UsrSenha { get; set; }
        public int? UsrAtivo { get; set; }
    }
}
