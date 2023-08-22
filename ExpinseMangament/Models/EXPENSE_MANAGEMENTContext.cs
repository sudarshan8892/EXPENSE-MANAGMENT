using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExpinseMangament.Models;

public partial class EXPENSE_MANAGEMENTContext : DbContext
{
    public EXPENSE_MANAGEMENTContext()
    {
    }

    public EXPENSE_MANAGEMENTContext(DbContextOptions<EXPENSE_MANAGEMENTContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DontTouch");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pk_Transaction");

            entity.HasOne(d => d.Category).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
