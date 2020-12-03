using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BDLab3
{
    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
        {
        }

        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<SeatRow> SeatRows { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Cinema;Username=postgres;Password=qwerty");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("Film");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.Duration)
                    .HasColumnType("character varying")
                    .HasColumnName("duration");

                entity.Property(e => e.FilmName)
                    .HasColumnType("character varying")
                    .HasColumnName("film_name");
            });

            modelBuilder.Entity<Passport>(entity =>
            {
                entity.ToTable("Passport");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Passport)
                    .HasForeignKey<Passport>(d => d.Id)
                    .HasConstraintName("id");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.RoomColour)
                    .HasColumnType("character varying")
                    .HasColumnName("room_colour");
            });

            modelBuilder.Entity<SeatRow>(entity =>
            {
                entity.ToTable("Seat/Row");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.RowId).HasColumnName("row_id");

                entity.Property(e => e.SeatId).HasColumnName("seat_id");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.HasIndex(e => e.StFilmId, "fki_st_film_id");

                entity.HasIndex(e => e.StRoomId, "fki_st_room_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"ShowTime_id_seq\"'::regclass)");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.StFilmId)
                    .HasColumnName("st_film_id")
                    .HasDefaultValueSql("nextval('\"ShowTime_film_id_seq\"'::regclass)");

                entity.Property(e => e.StRoomId)
                    .HasColumnName("st_room_id")
                    .HasDefaultValueSql("nextval('\"ShowTime_room_id_seq\"'::regclass)");

                entity.HasOne(d => d.StFilm)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.StFilmId)
                    .HasConstraintName("st_film_id");

                entity.HasOne(d => d.StRoom)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.StRoomId)
                    .HasConstraintName("st_room_id");
            });

            modelBuilder.Entity<Telephone>(entity =>
            {
                entity.ToTable("Telephone");

                entity.HasIndex(e => e.ClientId, "fki_client_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Telephone)
                    .HasForeignKey<Telephone>(d => d.Id)
                    .HasConstraintName("client_id");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.HasIndex(e => e.PlaceId, "fki_place_id");

                entity.HasIndex(e => e.SessionId, "fki_session_id");

                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("ticket_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("client_id");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("place_id");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("session_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
