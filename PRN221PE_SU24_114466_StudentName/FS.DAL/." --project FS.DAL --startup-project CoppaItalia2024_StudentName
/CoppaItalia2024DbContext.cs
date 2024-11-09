using System;
using System.Collections.Generic;
using FS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FS.DAL.." --project FS.DAL --startup-project CoppaItalia2024_StudentName
;

public partial class CoppaItalia2024DbContext : DbContext
{
    public CoppaItalia2024DbContext()
    {
    }

    public CoppaItalia2024DbContext(DbContextOptions<CoppaItalia2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoppaItaliaAccount> CoppaItaliaAccounts { get; set; }

    public virtual DbSet<CoppaItaliaClub> CoppaItaliaClubs { get; set; }

    public virtual DbSet<CoppaItaliaPlayer> CoppaItaliaPlayers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CoppaItalia2024DB;UID=sa;PWD=MyStrongPassword123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoppaItaliaAccount>(entity =>
        {
            entity.HasKey(e => e.AccId).HasName("PK__CoppaIta__91CBC3983DC2ABDB");

            entity.ToTable("CoppaItaliaAccount");

            entity.HasIndex(e => e.EmailAddress, "UQ__CoppaIta__49A14740B39042CA").IsUnique();

            entity.Property(e => e.AccId)
                .ValueGeneratedNever()
                .HasColumnName("AccID");
            entity.Property(e => e.AccDescription).HasMaxLength(140);
            entity.Property(e => e.AccPassword).HasMaxLength(90);
            entity.Property(e => e.EmailAddress).HasMaxLength(90);
        });

        modelBuilder.Entity<CoppaItaliaClub>(entity =>
        {
            entity.HasKey(e => e.CoppaItaliaClubId).HasName("PK__CoppaIta__1FBF3FA620B91026");

            entity.ToTable("CoppaItaliaClub");

            entity.Property(e => e.CoppaItaliaClubId)
                .HasMaxLength(20)
                .HasColumnName("CoppaItaliaClubID");
            entity.Property(e => e.ClubName).HasMaxLength(100);
            entity.Property(e => e.CurrentPresident).HasMaxLength(100);
            entity.Property(e => e.FoundedDate).HasColumnType("datetime");
            entity.Property(e => e.Ground).HasMaxLength(120);
            entity.Property(e => e.ShortDescription).HasMaxLength(250);
            entity.Property(e => e.Website).HasMaxLength(250);
        });

        modelBuilder.Entity<CoppaItaliaPlayer>(entity =>
        {
            entity.HasKey(e => e.CoppaItaliaPlayerId).HasName("PK__CoppaIta__4E2E3FF31E58BDBB");

            entity.ToTable("CoppaItaliaPlayer");

            entity.Property(e => e.CoppaItaliaPlayerId)
                .HasMaxLength(30)
                .HasColumnName("CoppaItaliaPlayerID");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CoppaItaliaClubId)
                .HasMaxLength(20)
                .HasColumnName("CoppaItaliaClubID");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.InternationalCareer).HasMaxLength(400);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.StyleOfPlay).HasMaxLength(400);

            entity.HasOne(d => d.CoppaItaliaClub).WithMany(p => p.CoppaItaliaPlayers)
                .HasForeignKey(d => d.CoppaItaliaClubId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CoppaItal__Coppa__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
