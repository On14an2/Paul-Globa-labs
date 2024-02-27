using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GlobaLab2.Models;

public partial class GlobaLab2Context : DbContext
{
    public GlobaLab2Context()
    {
    }

    public GlobaLab2Context(DbContextOptions<GlobaLab2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<GoodsInOrder> GoodsInOrders { get; set; }

    public virtual DbSet<IssuingOrder> IssuingOrders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PickUpPoint> PickUpPoints { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Globa_Lab2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC2735B8984B");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3214EC274B4E69A5");

            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdPickUpPoint).HasColumnName("ID_Pick_up_Point");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");

            entity.HasOne(d => d.IdPickUpPointNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPickUpPoint)
                .HasConstraintName("FK__employees__ID_Pi__08B54D69");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__goods__3214EC272C2454DB");

            entity.ToTable("goods");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdSellers).HasColumnName("ID_Sellers");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdSellersNavigation).WithMany(p => p.Goods)
                .HasForeignKey(d => d.IdSellers)
                .HasConstraintName("FK__goods__ID_Seller__0B91BA14");
        });

        modelBuilder.Entity<GoodsInOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__goods_in__3214EC273D8CD320");

            entity.ToTable("goods_in_order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdGoods).HasColumnName("ID_goods");
            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

            entity.HasOne(d => d.IdGoodsNavigation).WithMany(p => p.GoodsInOrders)
                .HasForeignKey(d => d.IdGoods)
                .HasConstraintName("FK__goods_in___ID_go__1332DBDC");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.GoodsInOrders)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK__goods_in___ID_Or__123EB7A3");
        });

        modelBuilder.Entity<IssuingOrder>(entity =>
        {
            entity.HasKey(e => e.OrderPlacement).HasName("PK__issuing___8F982954F65B75A7");

            entity.ToTable("issuing_orders");

            entity.Property(e => e.OrderPlacement)
                .ValueGeneratedNever()
                .HasColumnName("order_placement");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IdEmployees).HasColumnName("ID_Employees");
            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

            entity.HasOne(d => d.IdEmployeesNavigation).WithMany(p => p.IssuingOrders)
                .HasForeignKey(d => d.IdEmployees)
                .HasConstraintName("FK__issuing_o__ID_Em__160F4887");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.IssuingOrders)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK__issuing_o__ID_Or__17036CC0");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3214EC275CE4264C");

            entity.ToTable("orders");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdClient).HasColumnName("ID_Client");
            entity.Property(e => e.IdPickUpPoint).HasColumnName("ID_Pick_up_Point");
            entity.Property(e => e.SellarySum)
                .HasColumnType("money")
                .HasColumnName("Sellary_Sum");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK__orders__ID_Clien__0F624AF8");

            entity.HasOne(d => d.IdPickUpPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPickUpPoint)
                .HasConstraintName("FK__orders__ID_Pick___0E6E26BF");
        });

        modelBuilder.Entity<PickUpPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pick_up___3214EC27776C6807");

            entity.ToTable("Pick_up_Points");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sellers__3214EC274233C9F0");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
