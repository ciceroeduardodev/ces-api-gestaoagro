using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ces.api.gestaoagro.Models
{
    public partial class cessoftwareContext : DbContext
    {
        public cessoftwareContext()
        {
        }

        public cessoftwareContext(DbContextOptions<cessoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Balanca> Balancas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Entidade> Entidades { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Movimento> Movimentos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Program.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Balanca>(entity =>
            {
                entity.HasKey(e => new { e.CliId, e.BalId })
                    .HasName("PK__BALANCA__B057A394B8E86C42");

                entity.ToTable("BALANCA", "gestaoAgro");

                entity.Property(e => e.CliId).HasColumnName("CLI_Id");

                entity.Property(e => e.BalId).HasColumnName("BAL_Id");

                entity.Property(e => e.BalAtivo).HasColumnName("BAL_Ativo");

                entity.Property(e => e.BalNome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BAL_Nome");

                entity.Property(e => e.BalTicketBcc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BAL_Ticket_Bcc");

                entity.Property(e => e.BalTicketBco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BAL_Ticket_Bco");

                entity.Property(e => e.BalTicketTo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BAL_Ticket_To");

                entity.Property(e => e.BalToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BAL_Token");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CliId)
                    .HasName("PK__CLIENTE__D0BA12208E986AE7");

                entity.ToTable("CLIENTE", "gestaoAgro");

                entity.Property(e => e.CliId)
                    .ValueGeneratedNever()
                    .HasColumnName("CLI_Id");

                entity.Property(e => e.CliAtivo).HasColumnName("CLI_Ativo");

                entity.Property(e => e.CliData)
                    .HasColumnType("datetime")
                    .HasColumnName("CLI_Data");

                entity.Property(e => e.CliNome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLI_Nome");

                entity.Property(e => e.CliToken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLI_Token");
            });

            modelBuilder.Entity<Entidade>(entity =>
            {
                entity.HasKey(e => new { e.CliId, e.EntId })
                    .HasName("PK__ENTIDADE__530CBDA050A2403A");

                entity.ToTable("ENTIDADE", "gestaoAgro");

                entity.Property(e => e.CliId).HasColumnName("CLI_Id");

                entity.Property(e => e.EntId).HasColumnName("ENT_Id");

                entity.Property(e => e.EntAtivo).HasColumnName("ENT_Ativo");

                entity.Property(e => e.EntCpfCnpj)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("ENT_CPF_CNPJ");

                entity.Property(e => e.EntEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENT_Email");

                entity.Property(e => e.EntNome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ENT_Nome");

                entity.Property(e => e.EntTipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENT_Tipo")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => new { e.CliId, e.LogId })
                    .HasName("PK__LOG__E48C5EAEC44B5ACA");

                entity.ToTable("LOG", "gestaoAgro");

                entity.Property(e => e.CliId).HasColumnName("CLI_Id");

                entity.Property(e => e.LogId).HasColumnName("LOG_Id");

                entity.Property(e => e.LogData)
                    .HasColumnType("datetime")
                    .HasColumnName("LOG_Data");

                entity.Property(e => e.LogTexto)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("LOG_Texto");

                entity.Property(e => e.LogTextoBreve)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOG_TextoBreve");

                entity.Property(e => e.LogTipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOG_Tipo");
            });

            modelBuilder.Entity<Movimento>(entity =>
            {
                entity.HasKey(e => new { e.CliId, e.MovId })
                    .HasName("PK__MOVIMENT__77FA6CFA9E0D30EA");

                entity.ToTable("MOVIMENTO", "gestaoAgro");

                entity.Property(e => e.CliId).HasColumnName("CLI_Id");

                entity.Property(e => e.MovId).HasColumnName("MOV_Id");

                entity.Property(e => e.BalId).HasColumnName("BAL_Id");

                entity.Property(e => e.MovAtivo).HasColumnName("MOV_Ativo");

                entity.Property(e => e.MovCancelData)
                    .HasColumnType("datetime")
                    .HasColumnName("MOV_CancelData");

                entity.Property(e => e.MovCancelJust)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MOV_CancelJust");

                entity.Property(e => e.MovCargaPeso)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("MOV_CargaPeso");

                entity.Property(e => e.MovCliente).HasColumnName("MOV_Cliente");

                entity.Property(e => e.MovEntradaData)
                    .HasColumnType("datetime")
                    .HasColumnName("MOV_EntradaData");

                entity.Property(e => e.MovEntradaPeso)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("MOV_EntradaPeso");

                entity.Property(e => e.MovEntradaUsuario).HasColumnName("MOV_EntradaUsuario");

                entity.Property(e => e.MovFornecedor).HasColumnName("MOV_Fornecedor");

                entity.Property(e => e.MovImpressao).HasColumnName("MOV_Impressao");

                entity.Property(e => e.MovIntegrado)
                    .HasColumnType("datetime")
                    .HasColumnName("MOV_Integrado");

                entity.Property(e => e.MovMotorista).HasColumnName("MOV_Motorista");

                entity.Property(e => e.MovNotaFiscal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOV_NotaFiscal");

                entity.Property(e => e.MovNotaFiscalPeso)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("MOV_NotaFiscalPeso");

                entity.Property(e => e.MovObservacao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MOV_Observacao");

                entity.Property(e => e.MovPlaca)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MOV_Placa");

                entity.Property(e => e.MovSaidaData)
                    .HasColumnType("datetime")
                    .HasColumnName("MOV_SaidaData");

                entity.Property(e => e.MovSaidaPeso)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("MOV_SaidaPeso");

                entity.Property(e => e.MovSaidaUsuario).HasColumnName("MOV_SaidaUsuario");

                entity.Property(e => e.MovTicket)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOV_Ticket");

                entity.Property(e => e.MovTipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MOV_Tipo")
                    .IsFixedLength(true);

                entity.Property(e => e.MovTransportadora).HasColumnName("MOV_Transportadora");

                entity.Property(e => e.PrdId).HasColumnName("PRD_Id");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => new { e.CliId, e.PrdId })
                    .HasName("PK__PRODUTO__50F1CA8C2884D393");

                entity.ToTable("PRODUTO", "gestaoAgro");

                entity.Property(e => e.CliId).HasColumnName("CLI_Id");

                entity.Property(e => e.PrdId).HasColumnName("PRD_Id");

                entity.Property(e => e.PrdAtivo).HasColumnName("PRD_Ativo");

                entity.Property(e => e.PrdNome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRD_Nome");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => new { e.CliId, e.UsrId })
                    .HasName("PK__USUARIO__A9A7F001055E79D9");

                entity.ToTable("USUARIO", "gestaoAgro");

                entity.Property(e => e.CliId).HasColumnName("CLI_Id");

                entity.Property(e => e.UsrId).HasColumnName("USR_Id");

                entity.Property(e => e.UsrAlias)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USR_Alias");

                entity.Property(e => e.UsrAtivo).HasColumnName("USR_Ativo");

                entity.Property(e => e.UsrEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USR_Email");

                entity.Property(e => e.UsrNome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USR_Nome");

                entity.Property(e => e.UsrSenha)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USR_Senha");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
