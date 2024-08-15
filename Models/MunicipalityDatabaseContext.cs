using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ST10095103_Part1_PROG7312_MunicipalityWebsite.Models;

public partial class MunicipalityDatabaseContext : DbContext
{
    public MunicipalityDatabaseContext()
    {
    }

    public MunicipalityDatabaseContext(DbContextOptions<MunicipalityDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategorySelection> CategorySelections { get; set; }

    public virtual DbSet<ReportIssue> ReportIssues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-53LFRIQ3;Initial Catalog=MunicipalityDatabase;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategorySelection>(entity =>
        {
            entity.HasKey(e => e.CategorySelectionId).HasName("PK__Category__29ED51DD8ABEA806");

            entity.ToTable("CategorySelection");

            entity.Property(e => e.CategorySelectionId)
                .ValueGeneratedNever()
                .HasColumnName("CategorySelectionID");
            entity.Property(e => e.Categories)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReportIssue>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PK__reportIs__6C8616248D41200A");

            entity.ToTable("reportIssue");

            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.CategorySelectionId).HasColumnName("CategorySelectionID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FilePath).HasMaxLength(255);
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IssueDescription).HasColumnType("text");
            entity.Property(e => e.IssueLocation)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CategorySelection).WithMany(p => p.ReportIssues)
                .HasForeignKey(d => d.CategorySelectionId)
                .HasConstraintName("FK__reportIss__Creat__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
