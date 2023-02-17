using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD.Models;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItemTable> ItemTables { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemTable>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("ItemTable");

            entity.Property(e => e.ItemId).HasColumnName("item_Id");
            entity.Property(e => e.ItemInsertTime)
                .HasColumnType("datetime")
                .HasColumnName("item_InsertTime");
            entity.Property(e => e.ItemName)
                .HasMaxLength(10)
                .HasColumnName("item_Name");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserTable");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_Id");
            entity.Property(e => e.UserAccount)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("user_Account");
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .HasColumnName("user_Name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(35)
                .HasColumnName("user_Password");
            entity.Property(e => e.UserSingupTime)
                .HasColumnType("datetime")
                .HasColumnName("user_SingupTime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
