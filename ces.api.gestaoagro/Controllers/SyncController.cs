using ces.api.gestaoagro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ces.api.gestaoagro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private readonly gestaoagroContext _context;

        public SyncController(gestaoagroContext context)
        {
            _context = context;
        }

        // GET: api/ping
        [HttpGet("ping")]
        public ActionResult<bool> Ping()
        {
            return true;
        }


        // POST: api/Sync
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostSync(Sync sync)
        {
            DateTime dataRef = Classes.Helpers.Get_DateTime_TimeZone_Brazil();
            try
            {

                if (sync.Balanca == null || sync.Balanca.BAL_Token == null)
                    return NotFound();

                /////////////////////////////////////////////////////
                // Atualizar tabela BALANCA
                /////////////////////////////////////////////////////

                Balanca balanca;

                if (!_context.Balancas.Any(x => x.BalToken == sync.Balanca.BAL_Token))
                {
                    return NotFound();
                }
                else
                {

                    balanca = await _context.Balancas.Where(x => x.BalToken == sync.Balanca.BAL_Token).FirstAsync();
                    balanca.BalTicketTo = sync.Balanca.BAL_Ticket_To;
                    balanca.BalTicketBcc = sync.Balanca.BAL_Ticket_Bcc;
                    balanca.BalTicketBco = sync.Balanca.BAL_Ticket_co;
                    _context.Entry(balanca).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                /////////////////////////////////////////////////////
                // Atualizar tabela PRODUTO
                /////////////////////////////////////////////////////

                if (sync.Produtos != null)
                {
                    Produto produto;

                    foreach (syncPRODUTO item in sync.Produtos)
                    {
                        produto = new Produto { CliId = balanca.CliId, BalId = balanca.BalId, PrdId = item.PRD_Id, PrdNome = item.PRD_Nome, PrdAtivo = 1 };

                        if (_context.Produtos.Any(x => x.CliId == balanca.CliId && x.BalId == balanca.BalId && x.PrdId == item.PRD_Id))
                            _context.Entry(produto).State = EntityState.Modified;
                        else
                            _context.Produtos.Add(produto);

                    }

                    await _context.SaveChangesAsync();
                }


                /////////////////////////////////////////////////////
                // Atualizar tabela ENTIDADE
                /////////////////////////////////////////////////////

                if (sync.Entidades != null)
                {
                    Entidade entidade;

                    foreach (syncENTIDADE item in sync.Entidades)
                    {
                        entidade = new Entidade
                        {
                            CliId = balanca.CliId,
                            BalId = balanca.BalId,
                            EntId = item.ENT_Id,
                            EntNome = item.ENT_Nome,
                            EntTipo = item.ENT_Tipo,
                            EntCpfCnpj = item.ENT_CPF_CNPJ,
                            EntEmail = item.ENT_Email,
                            EntAtivo = item.ENT_Ativo
                        };

                        if (_context.Entidades.Any(x => x.CliId == balanca.CliId && x.BalId == balanca.BalId && x.EntId == item.ENT_Id))
                            _context.Entry(entidade).State = EntityState.Modified;
                        else
                            _context.Entidades.Add(entidade);

                    }

                    await _context.SaveChangesAsync();
                }

                /////////////////////////////////////////////////////
                // Atualizar tabela MOVIMENTO
                /////////////////////////////////////////////////////

                if (sync.Movimentos != null)
                {
                    Movimento movimento;
                    foreach (syncMOVIMENTO item in sync.Movimentos)
                    {
                        try
                        {
                            movimento = new Movimento
                            {
                                CliId = balanca.CliId,
                                BalId = balanca.BalId,
                                MovId = item.MOV_Id,
                                MovTicket = item.MOV_Ticket,
                                MovTipo = item.MOV_Tipo,
                                MovPlaca = item.MOV_Placa,
                                MovNotaFiscal = item.MOV_NotaFiscal,
                                MovNotaFiscalPeso = Convert.ToDecimal(item.MOV_NotaFiscalPeso),
                                MovMotorista = item.Motorista.ENT_Id,
                                MovCliente = item.Cliente.ENT_Id,
                                MovFornecedor = item.Fornecedor.ENT_Id,
                                MovTransportadora = item.Transportadora.ENT_Id,
                                PrdId = item.PRD.PRD_Id,
                                MovObservacao = item.MOV_Observacao,
                                MovEntradaData = SetDateTime( item.MOV_EntradaData),
                                MovEntradaPeso = Convert.ToDecimal(item.MOV_EntradaPeso),
                                MovEntradaUsuario = item.MOV_EntradaUsuario,
                                MovSaidaData = SetDateTime(item.MOV_SaidaData),
                                MovSaidaPeso = Convert.ToDecimal(item.MOV_SaidaPeso),
                                MovSaidaUsuario = item.MOV_SaidaUsuario,
                                MovCargaPeso = Convert.ToDecimal(item.MOV_CargaPeso),
                                MovImpressao = item.MOV_Impressao,
                                MovAtivo = item.MOV_Ativo,
                                MovCancelJust = item.MOV_CancelJust,
                                MovCancelData = SetDateTime(item.MOV_CancelData),
                                MovIntegrado = dataRef,
                            };

                            if (_context.Movimentos.Any(x => x.CliId == balanca.CliId && x.BalId == balanca.BalId && x.MovId == item.MOV_Id))
                                _context.Entry(movimento).State = EntityState.Modified;
                            else
                                _context.Movimentos.Add(movimento);

                            await _context.SaveChangesAsync();

                        }
                        catch (Exception ex)
                        {
                            Log log = new Log();
                            log.CliId = sync.Balanca.CLI_Id;
                            log.BalId = sync.Balanca.BAL_Id;
                            log.LogId = _context.Logs.Where(x => x.CliId == sync.Balanca.CLI_Id && x.BalId == sync.Balanca.BAL_Id).Max(x => x.LogId) + 1;
                            log.LogTipo = "E";
                            log.LogTextoBreve = "Processo Sincronismo";
                            log.LogTexto = ex.ToString();
                            log.LogData = DateTime.Now;
                            _context.Logs.Add(log);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok();

        }

        private DateTime? SetDateTime(DateTime? value)
        {
            if (value.Value.Year < 1900)
                return null;

            return value;

        }


    }
}
