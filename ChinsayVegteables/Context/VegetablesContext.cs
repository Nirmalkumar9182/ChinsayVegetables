using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ChinsayVegteables.models;

namespace ChinsayVegteables.Context
{
    public partial class VegetablesContext : DbContext
    {
        public VegetablesContext()
        {
        }

        public VegetablesContext(DbContextOptions<VegetablesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VegeDetails> VegeDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=..\\DB\\VegetablesDb.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VegeDetails>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
