using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreImport.Models.DBF
{
    public partial class CharterFlightsContext : DbContext
    {
        public CharterFlightsContext()
        {
        }

        public CharterFlightsContext(DbContextOptions<CharterFlightsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthPerson> AuthPerson { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<PaxData> PaxData { get; set; }
        public virtual DbSet<PaxSsr> PaxSsr { get; set; }

        // Unable to generate entity type for table 'dbo.PaxDataHist'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SSR'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TravelAgency'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(" Server = DESKTOP-B9LK0H2\\SQLEXPRESS; Initial Catalog = CharterFlights; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthPerson>(entity =>
            {
                entity.Property(e => e.PersonName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonRole)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.Property(e => e.FlightDate).HasColumnType("date");

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.TelNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<PaxData>(entity =>
            {
                entity.Property(e => e.ChangedType)
                     .HasMaxLength(255)
                     .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Document)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Escort)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expires).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PaxOrder)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResNumber)
                    .HasColumnName("resNumber")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Seats)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceYj)
                    .HasColumnName("ServiceYJ")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ssr)
                    .HasColumnName("SSR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.PaxData)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_FlightId");
            });

            modelBuilder.Entity<PaxSsr>(entity =>
            {
                entity.ToTable("PaxSSR");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionSsr)
                    .HasColumnName("DescriptionSSR")
                    .HasMaxLength(255);

                entity.Property(e => e.F1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F10)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F5)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F6)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F7)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F8)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.F9)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PaxId).HasColumnName("PaxID");

                entity.HasOne(d => d.Pax)
                    .WithMany(p => p.PaxSsr)
                    .HasForeignKey(d => d.PaxId)
                    .HasConstraintName("FK_PaxID");
            });
            }
    }
}
