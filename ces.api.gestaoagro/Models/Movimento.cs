using System;
using System.Collections.Generic;

#nullable disable

namespace ces.api.gestaoagro.Models
{
    public partial class Movimento
    {
        public int CliId { get; set; }
        public int BalId { get; set; }
        public int MovId { get; set; }
        public string MovTicket { get; set; }
        public string MovTipo { get; set; }
        public string MovPlaca { get; set; }
        public string MovNotaFiscal { get; set; }
        public decimal? MovNotaFiscalPeso { get; set; }
        public int? MovMotorista { get; set; }
        public int? MovCliente { get; set; }
        public int? MovFornecedor { get; set; }
        public int? MovTransportadora { get; set; }
        public int? PrdId { get; set; }
        public string MovObservacao { get; set; }
        public DateTime? MovEntradaData { get; set; }
        public decimal? MovEntradaPeso { get; set; }
        public int? MovEntradaUsuario { get; set; }
        public DateTime? MovSaidaData { get; set; }
        public decimal? MovSaidaPeso { get; set; }
        public int? MovSaidaUsuario { get; set; }
        public decimal? MovCargaPeso { get; set; }
        public int? MovImpressao { get; set; }
        public int? MovAtivo { get; set; }
        public string MovCancelJust { get; set; }
        public DateTime? MovCancelData { get; set; }
        public DateTime? MovIntegrado { get; set; }
    }
}
