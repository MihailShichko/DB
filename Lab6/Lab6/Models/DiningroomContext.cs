using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Models;

public partial class DiningroomContext : DbContext
{
    public DiningroomContext()
    {
    }

    public DiningroomContext(DbContextOptions<DiningroomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Coock> Coocks { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderCoock> OrderCoocks { get; set; }

    public virtual DbSet<OrderMenu> OrderMenus { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=diningroom; Username=postgres; Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(256)
                .HasColumnName("fullname");
            entity.Property(e => e.Telephonenumber)
                .HasMaxLength(32)
                .HasColumnName("telephonenumber");
        });

        modelBuilder.Entity<Coock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("coocks_pkey");

            entity.ToTable("coocks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.Payment).HasColumnName("payment");
            entity.Property(e => e.Post).HasColumnName("post");
            entity.Property(e => e.Specialization).HasColumnName("specialization");
            entity.Property(e => e.Telephonenumber)
                .HasMaxLength(64)
                .HasColumnName("telephonenumber");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menu_pkey");

            entity.ToTable("menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Compaund)
                .HasMaxLength(256)
                .HasColumnName("compaund");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.OrderMenuId).HasColumnName("order_menu_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("orders_client_id_fkey");

            entity.HasOne(d => d.OrderMenu).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderMenuId)
                .HasConstraintName("orders_order_menu_id_fkey");
        });

        modelBuilder.Entity<OrderCoock>(entity =>
        {
            entity.HasKey(e => new { e.Coockid, e.Ordernum }).HasName("order_coock_pkey");

            entity.ToTable("order_coock");

            entity.Property(e => e.Coockid).HasColumnName("coockid");
            entity.Property(e => e.Ordernum).HasColumnName("ordernum");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Coock).WithMany(p => p.OrderCoocks)
                .HasForeignKey(d => d.Coockid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_coock_coockid_fkey");

            entity.HasOne(d => d.OrdernumNavigation).WithMany(p => p.OrderCoocks)
                .HasForeignKey(d => d.Ordernum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_coock_ordernum_fkey");
        });

        modelBuilder.Entity<OrderMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_menu_pkey");

            entity.ToTable("order_menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");

            entity.HasOne(d => d.Menu).WithMany(p => p.OrderMenus)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("order_menu_menu_id_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentType).HasColumnName("payment_type");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("payments_order_id_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reviews_pkey");

            entity.ToTable("reviews");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Order).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("reviews_order_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
