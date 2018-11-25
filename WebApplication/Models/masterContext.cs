using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Joueurs> Joueurs { get; set; }
        public virtual DbSet<Repas> Repas { get; set; }
        public virtual DbSet<TransactionArgent> TransactionArgent { get; set; }
        public virtual DbSet<TypeRepas> TypeRepas { get; set; }

        // Unable to generate entity type for table 'dbo.participation'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Joueurs>(entity =>
            {
                entity.ToTable("joueurs");

                entity.HasIndex(e => e.Usager)
                    .HasName("UQ__joueurs__909781015608A57A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mdp)
                    .IsRequired()
                    .HasColumnName("mdp")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Solde)
                    .HasColumnName("solde")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StatPerte).HasColumnName("stat_perte");

                entity.Property(e => e.Usager)
                    .IsRequired()
                    .HasColumnName("usager")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Repas>(entity =>
            {
                entity.ToTable("repas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Assistant).HasColumnName("assistant");

                entity.Property(e => e.Cook).HasColumnName("cook");

                entity.Property(e => e.DateRepas)
                    .HasColumnName("date_repas")
                    .HasColumnType("date");

                entity.Property(e => e.Repas1).HasColumnName("repas");

                entity.Property(e => e.Vaissaileux).HasColumnName("vaissaileux");

                entity.HasOne(d => d.AssistantNavigation)
                    .WithMany(p => p.RepasAssistantNavigation)
                    .HasForeignKey(d => d.Assistant)
                    .HasConstraintName("repas_fk2");

                entity.HasOne(d => d.CookNavigation)
                    .WithMany(p => p.RepasCookNavigation)
                    .HasForeignKey(d => d.Cook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("repas_fk1");

                entity.HasOne(d => d.Repas1Navigation)
                    .WithMany(p => p.Repas)
                    .HasForeignKey(d => d.Repas1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("repas_fk0");

                entity.HasOne(d => d.VaissaileuxNavigation)
                    .WithMany(p => p.RepasVaissaileuxNavigation)
                    .HasForeignKey(d => d.Vaissaileux)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("repas_fk3");
            });

            modelBuilder.Entity<TransactionArgent>(entity =>
            {
                entity.ToTable("transaction_argent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Joueur).HasColumnName("joueur");

                entity.Property(e => e.Montant).HasColumnName("montant");

                entity.Property(e => e.Repas).HasColumnName("repas");

                entity.HasOne(d => d.JoueurNavigation)
                    .WithMany(p => p.TransactionArgent)
                    .HasForeignKey(d => d.Joueur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transaction_argent_fk0");

                entity.HasOne(d => d.RepasNavigation)
                    .WithMany(p => p.TransactionArgent)
                    .HasForeignKey(d => d.Repas)
                    .HasConstraintName("transaction_argent_fk1");
            });

            modelBuilder.Entity<TypeRepas>(entity =>
            {
                entity.ToTable("type_repas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
