using System;
using System.Collections.Generic;

#nullable disable

namespace ces.api.gestaoagro.Models
{
    public partial class Log
    {
        public int CliId { get; set; }
        public int LogId { get; set; }
        public string LogTipo { get; set; }
        public string LogTextoBreve { get; set; }
        public string LogTexto { get; set; }
        public DateTime? LogData { get; set; }
    }
}
