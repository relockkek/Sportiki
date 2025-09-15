using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Sportiki.DB;

public partial class Sportiki1135Context : DbContext
{
    public Sportiki1135Context()
    {
    }

    public Sportiki1135Context(DbContextOptions<Sportiki1135Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Athlete> Athletes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Participation> Participations { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("userid=student;password=student;database=Sportiki1135;server=192.168.200.13", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("athletes");

            entity.HasIndex(e => e.CategoryId, "FK_athletes_category_id");

            entity.HasIndex(e => e.LevelId, "FK_athletes_level_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("category_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.LevelId)
                .HasColumnType("int(11)")
                .HasColumnName("level_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Athletes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_athletes_category_id");

            entity.HasOne(d => d.Level).WithMany(p => p.Athletes)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK_athletes_level_id");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Category1)
                .HasMaxLength(255)
                .HasColumnName("category");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("level");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Level1)
                .HasMaxLength(255)
                .HasColumnName("level");
        });

        modelBuilder.Entity<Participation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("participation");

            entity.HasIndex(e => e.AthleteId, "FK_participation_athletes_id");

            entity.HasIndex(e => e.TrainingId, "FK_participation_trainings_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AthleteId)
                .HasColumnType("int(11)")
                .HasColumnName("athlete_id");
            entity.Property(e => e.TrainingId)
                .HasColumnType("int(11)")
                .HasColumnName("training_id");

            entity.HasOne(d => d.Athlete).WithMany(p => p.Participations)
                .HasForeignKey(d => d.AthleteId)
                .HasConstraintName("FK_participation_athletes_id");

            entity.HasOne(d => d.Training).WithMany(p => p.Participations)
                .HasForeignKey(d => d.TrainingId)
                .HasConstraintName("FK_participation_trainings_id");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trainings");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.DateTime)
                .HasMaxLength(255)
                .HasColumnName("date_time");
            entity.Property(e => e.Duration)
                .HasMaxLength(255)
                .HasColumnName("duration");
            entity.Property(e => e.Estimation)
                .HasColumnType("tinyint(4)")
                .HasColumnName("estimation");
            entity.Property(e => e.Title)
                .HasColumnType("int(11)")
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
