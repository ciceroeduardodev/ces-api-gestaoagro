using System;
using System.Collections.Generic;

#nullable disable

namespace ces.api.gestaoagro.Models
{
    public partial class Balanca
    {
        public int CliId { get; set; }
        public int BalId { get; set; }
        public string BalNome { get; set; }
        public string BalToken { get; set; }
        public string BalTicketTo { get; set; }
        public string BalTicketBcc { get; set; }
        public string BalTicketBco { get; set; }
        public int? BalAtivo { get; set; }
    }
}
