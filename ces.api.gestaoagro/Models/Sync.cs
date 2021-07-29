using System;
using System.Collections.Generic;


namespace ces.api.gestaoagro.Models
{
    public class Sync
    {
        public syncCLIENTE Cliente { get; set; }
        public List<syncENTIDADE> Entidades { get; set; }
        public List<syncPRODUTO> Produtos { get; set; }
        public syncBALANCA Balanca { get; set; }
        public List<syncMOVIMENTO> Movimentos { get; set; }
    }

    public class syncENTIDADE
    {
        public int ENT_Id { get; set; }
        public string ENT_Nome { get; set; }
        public string ENT_Tipo { get; set; }
        public string ENT_CPF_CNPJ { get; set; }
        public string ENT_Email { get; set; }
        public int ENT_Ativo { get; set; }
    }

    public class syncCLIENTE
    {
        private int CLI_Id { get; set; }
        private string CLI_Nome { get; set; }
        private string CLI_Token { get; set; }
        private DateTime CLI_Data { get; set; }
        private int CLI_Ativo { get; set; }
    }

    public class syncBALANCA
    {
        public int CLI_Id { get; set; }
        public int BAL_Id { get; set; }
        public string BAL_Nome { get; set; }
        public string BAL_Token { get; set; }
        public string BAL_Ticket_To { get; set; }
        public string BAL_Ticket_Bcc { get; set; }
        public string BAL_Ticket_co { get; set; }
        public int BAL_Ativo { get; set; }


    }

    public class syncMOVIMENTO
    {
        public int MOV_Id { get; set; }
        public string MOV_Ticket { get; set; }
        public string MOV_Tipo { get; set; }
        public string MOV_Placa { get; set; }
        public string MOV_NotaFiscal { get; set; }
        public double MOV_NotaFiscalPeso { get; set; }
        public string MOV_Observacao { get; set; }
        public DateTime MOV_EntradaData { get; set; }
        public double MOV_EntradaPeso { get; set; }
        public int MOV_EntradaUsuario { get; set; }
        public DateTime MOV_SaidaData { get; set; }
        public double MOV_SaidaPeso { get; set; }
        public int MOV_SaidaUsuario { get; set; }
        public double MOV_CargaPeso { get; set; }
        public int MOV_Impressao { get; set; }
        public int MOV_Ativo { get; set; }
        public string MOV_CancelJust { get; set; }
        public DateTime MOV_CancelData { get; set; }
        public DateTime MOV_Integrado { get; set; }

        public syncENTIDADE Motorista { get; set; }
        public syncENTIDADE Cliente { get; set; }
        public syncENTIDADE Fornecedor { get; set; }
        public syncENTIDADE Transportadora { get; set; }

        public syncPRODUTO PRD { get; set; }

    }

    public class syncPRODUTO
    {
        public int CLI_Id { get; set; }
        public int PRD_Id { get; set; }
        public string PRD_Nome { get; set; }
        public int PRD_Ativo { get; set; }
    }
}