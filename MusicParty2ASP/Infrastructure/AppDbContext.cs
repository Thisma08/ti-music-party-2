using Infrastructure.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DbMusic> Musics { get; set; }

    public virtual DbSet<DbUser> Users { get; set; }

    public virtual DbSet<DbVote> Votes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=musicparty_db_2;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbMusic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__musics__3213E83FF71C8956");

            entity.ToTable("musics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.YoutubeUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("youtubeUrl");

            entity.HasOne(d => d.DbUser).WithMany(p => p.Musics)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__musics__userId__3A81B327");
        });

        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FE7AC260A");

            entity.ToTable("users");

            entity.HasIndex(e => e.Pseudo, "UQ__users__EA0EEA22721D003D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Pseudo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pseudo");
        });

        modelBuilder.Entity<DbVote>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.MusicId }).HasName("PK__votes__312B3378950B6244");

            entity.ToTable("votes");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.MusicId).HasColumnName("musicId");

            entity.HasOne(d => d.DbMusic).WithMany(p => p.Votes)
                .HasForeignKey(d => d.MusicId)
                .HasConstraintName("FK__votes__musicId__3E52440B");

            entity.HasOne(d => d.DbUser).WithMany(p => p.Votes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__votes__userId__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
