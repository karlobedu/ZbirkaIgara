﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZbirkaIgara.Models;

namespace ZbirkaIgara.Data;

public partial class ZbirkaIgaraContext : DbContext
{
    public ZbirkaIgaraContext()
    {
    }

    public ZbirkaIgaraContext(DbContextOptions<ZbirkaIgaraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Igra> Igre { get; set; }

    public virtual DbSet<Zanr> Zanrovi { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Igra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Igra__3214EC07DDBF58E4");
            entity.ToTable("Igra");
            entity.Property(e => e.Hltb).HasColumnName("hltb");
            entity.Property(e => e.IdZanra).HasColumnName("Id_Zanra");
            entity.Property(e => e.Naslov)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ocjena)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("ocjena");
            entity.Property(e => e.Opis).IsUnicode(false);
            entity.Property(e => e.Platforme)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdZanraNavigation).WithMany(p => p.Igre)
                .HasForeignKey(d => d.IdZanra)
                .HasConstraintName("FK_Igra_Zanr");
        });

        modelBuilder.Entity<Zanr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Zanr__3214EC0721E31B49");

            entity.ToTable("Zanr");

            entity.Property(e => e.ImeZanra)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
