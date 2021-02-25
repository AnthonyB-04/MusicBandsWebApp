using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MusicBandsWebApp
{
    public partial class DBMusicBandsContext : DbContext
    {
        public DBMusicBandsContext()
        {
        }

        public DBMusicBandsContext(DbContextOptions<DBMusicBandsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumSong> AlbumSongs { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<BandMusician> BandMusicians { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-RB1F658; Database=DBMusicBands; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumId)
                    .ValueGeneratedNever()
                    .HasColumnName("AlbumID");

                entity.Property(e => e.AlbumGenre)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.AlbumTitle)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.BandId).HasColumnName("BandID");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Albums_Bands");
            });

            modelBuilder.Entity<AlbumSong>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.SongId });

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumSongs)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumSongs_Albums");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.AlbumSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumSongs_Songs");
            });

            modelBuilder.Entity<Band>(entity =>
            {
                entity.Property(e => e.BandId)
                    .ValueGeneratedNever()
                    .HasColumnName("BandID");

                entity.Property(e => e.BandName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Info).HasColumnType("ntext");
            });

            modelBuilder.Entity<BandMusician>(entity =>
            {
                entity.HasKey(e => new { e.BandId, e.MusicianId });

                entity.Property(e => e.BandId).HasColumnName("BandID");

                entity.Property(e => e.MusicianId).HasColumnName("MusicianID");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.BandMusicians)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BandMusicians_Bands");

                entity.HasOne(d => d.Musician)
                    .WithMany(p => p.BandMusicians)
                    .HasForeignKey(d => d.MusicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BandMusicians_Musicians");
            });

            modelBuilder.Entity<Musician>(entity =>
            {
                entity.Property(e => e.MusicianId)
                    .ValueGeneratedNever()
                    .HasColumnName("MusicianID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.Property(e => e.PlaylistId)
                    .ValueGeneratedNever()
                    .HasColumnName("PlaylistID");

                entity.Property(e => e.PlaylistTitle)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.HasKey(e => new { e.SongId, e.PlaylistId });

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistSongs_Playlists");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistSongs_Songs");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.SongId)
                    .ValueGeneratedNever()
                    .HasColumnName("SongID");

                entity.Property(e => e.SongLength)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.SongTitle)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
