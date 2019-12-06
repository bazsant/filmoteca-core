using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace filmoteca_core.Models
{
    public partial class FILMOTECAContext : DbContext
    {
        public FILMOTECAContext()
        {
        }

        public FILMOTECAContext(DbContextOptions<FILMOTECAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cotacao> Cotacao { get; set; }        
        public virtual DbSet<Filme> Filme { get; set; }
        public virtual DbSet<Parametrizacao> Parametrizacao { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotacao>(entity =>
            {
                entity.HasKey(e => e.CdCotacao);

                entity.ToTable("COTACAO");

                entity.Property(e => e.CdCotacao).HasColumnName("CD_COTACAO");

                entity.Property(e => e.CdFilme).HasColumnName("CD_FILME");

                entity.Property(e => e.CdPessoa).HasColumnName("CD_PESSOA");

                entity.Property(e => e.DtEntregaPrevista)
                    .HasColumnName("DT_ENTREGA_PREVISTA")
                    .HasColumnType("date");

                entity.Property(e => e.DtEntrega)
                    .HasColumnName("DT_ENTREGA")
                    .HasColumnType("date");

                entity.Property(e => e.FlEntregue)
                    .HasColumnName("FL_ENTREGUE")
                    .HasColumnType("bit");

                entity.Property(e => e.VlValor)
                    .HasColumnName("VL_VALOR")
                    .HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.CdFilmeNavigation)
                    .WithMany(p => p.Cotacao)
                    .HasForeignKey(d => d.CdFilme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COTACAO_FILME");

                entity.HasOne(d => d.CdPessoaNavigation)
                    .WithMany(p => p.Cotacao)
                    .HasForeignKey(d => d.CdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COTACAO_PESSOA");
            });

            
            modelBuilder.Entity<Filme>(entity =>
            {
                entity.HasKey(e => e.CdFilme);

                entity.ToTable("FILME");

                entity.Property(e => e.CdFilme).HasColumnName("CD_FILME");

                entity.Property(e => e.DsDiretor)
                    .HasColumnName("DS_DIRETOR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsElenco)
                    .HasColumnName("DS_ELENCO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DsEstudio)
                    .HasColumnName("DS_ESTUDIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsGenero)
                    .HasColumnName("DS_GENERO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsTitulo)
                    .HasColumnName("DS_TITULO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtLancamento)
                    .HasColumnName("DT_LANCAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.VlEstoque)
                    .HasColumnName("VL_ESTOQUE")
                    .HasColumnType("int");
            });

            modelBuilder.Entity<Parametrizacao>(entity =>
            {
                entity.HasKey(e => e.DsChave);

                entity.ToTable("PARAMETRIZACAO");

                entity.Property(e => e.DsChave)
                    .HasColumnName("DS_CHAVE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DsValor)
                    .IsRequired()
                    .HasColumnName("DS_VALOR")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.CdPerfil);

                entity.ToTable("PERFIL");

                entity.Property(e => e.CdPerfil).HasColumnName("CD_PERFIL");

                entity.Property(e => e.CdNivelAcesso).HasColumnName("CD_NIVEL_ACESSO");

                entity.Property(e => e.DsPerfil)
                    .IsRequired()
                    .HasColumnName("DS_PERFIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.CdPessoa);

                entity.ToTable("PESSOA");

                entity.Property(e => e.CdPessoa).HasColumnName("CD_PESSOA");

                entity.Property(e => e.CdPerfil).HasColumnName("CD_PERFIL");

                entity.Property(e => e.CdSexo).HasColumnName("CD_SEXO");

                entity.Property(e => e.CdUsuario).HasColumnName("CD_USUARIO");

                entity.Property(e => e.DsEmail)
                    .HasColumnName("DS_EMAIL")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.DsTelefone)
                    .HasColumnName("DS_TELEFONE")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DtNascimento)
                    .HasColumnName("DT_NASCIMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.NmPessoa)
                    .IsRequired()
                    .HasColumnName("NM_PESSOA")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdPerfilNavigation)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.CdPerfil)
                    .HasConstraintName("FK_PESSOA_PERFIL");

                entity.HasOne(d => d.CdUsuarioNavigation)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.CdUsuario)
                    .HasConstraintName("FK_PESSOA_USUARIO");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CdUsuario);

                entity.ToTable("USUARIO");

                entity.Property(e => e.CdUsuario).HasColumnName("CD_USUARIO");

                entity.Property(e => e.DsSenha)
                    .IsRequired()
                    .HasColumnName("DS_SENHA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NmUsuario)
                    .IsRequired()
                    .HasColumnName("NM_USUARIO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
