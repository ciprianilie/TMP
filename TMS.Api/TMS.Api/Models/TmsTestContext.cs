using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TMS.Api.Models;

public partial class TmsTestContext : DbContext
{
    public TmsTestContext()
    {
    }

    public TmsTestContext(DbContextOptions<TmsTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TMS;Integrated Security=True;TrustServerCertificate=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("Event");

            entity.HasIndex(e => e.EventTypeId, "IX_Event_EventTypeId");

            entity.HasIndex(e => e.VenueId, "IX_Event_VenueId");

            entity.Property(e => e.EventDescription).HasMaxLength(200);
            entity.Property(e => e.EventName).HasMaxLength(50);

            entity.HasOne(d => d.EventType).WithMany(p => p.Events).HasForeignKey(d => d.EventTypeId);

            entity.HasOne(d => d.Venue).WithMany(p => p.Events).HasForeignKey(d => d.VenueId);
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.ToTable("EventType");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.HasIndex(e => e.TicketCategoryId, "IX_Orders_TicketCategoryId");

            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customer_CustomerId");

            entity.HasOne(d => d.TicketCategory).WithMany(p => p.Orders).HasForeignKey(d => d.TicketCategoryId);
        });

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.ToTable("TicketCategory");

            entity.HasIndex(e => e.EventId, "IX_TicketCategory_EventId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketCategories).HasForeignKey(d => d.EventId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_Customer");

            entity.ToTable("User");

            entity.Property(e => e.CustomerName).HasMaxLength(50);
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.ToTable("Venue");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
