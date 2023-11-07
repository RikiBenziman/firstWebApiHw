﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class MySuperMarketContext : DbContext
{
    public MySuperMarketContext()
    {
    }

    public MySuperMarketContext(DbContextOptions<MySuperMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=MySuperMarket;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Table_1");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_NAME");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__ORDERS__460A9464743A689A");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.OderDate)
                .HasColumnType("date")
                .HasColumnName("ODER_DATE");
            entity.Property(e => e.OrderSum)
                .HasColumnType("money")
                .HasColumnName("ORDER_SUM");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS__USER_ID__3C69FB99");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__ORDERS_I__E15C43169EAB1E53");

            entity.ToTable("ORDER_ITEM");

            entity.Property(e => e.OrderItemId).HasColumnName("ORDER_ITEM_ID");
            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS_IT__ORDER__403A8C7D");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS_IT__PRODU__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS_IT__USER___412EB0B6");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__3214EC07A10199C3");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");
            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_DESCRIPTION");
            entity.Property(e => e.ProductImage)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_IMAGE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.ProductPrice).HasColumnName("PRODUCT_PRICE");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Catego__2A4B4B5E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Users");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USER_NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}