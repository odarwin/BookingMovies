using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookingMovie.Dominio.Entidades
{
    public partial class BookingMoviesDBContext : DbContext
    {
        public BookingMoviesDBContext()
        {
        }

        public BookingMoviesDBContext(DbContextOptions<BookingMoviesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaseEntity> BaseEntity { get; set; }
        public virtual DbSet<BillboardEntity> BillboardEntity { get; set; }
        public virtual DbSet<BookingEntity> BookingEntity { get; set; }
        public virtual DbSet<CustomerEntity> CustomerEntity { get; set; }
        public virtual DbSet<MovieEntity> MovieEntity { get; set; }
        public virtual DbSet<RoomEntity> RoomEntity { get; set; }
        public virtual DbSet<SeatEntity> SeatEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost; Database=BookingMoviesDB; Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillboardEntity>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.BillboardEntity)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_billboard_movie");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.BillboardEntity)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_room_billboard");
            });

            modelBuilder.Entity<BookingEntity>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Billboard)
                    .WithMany(p => p.BookingEntity)
                    .HasForeignKey(d => d.BillboardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Billboard");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BookingEntity)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_BookingEntity_CustomerEntity");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.BookingEntity)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Seat");
            });

            modelBuilder.Entity<CustomerEntity>(entity =>
            {
                entity.Property(e => e.DocumentNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovieEntity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomEntity>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SeatEntity>(entity =>
            {
                entity.HasOne(d => d.Room)
                    .WithMany(p => p.SeatEntity)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_room_seat");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
