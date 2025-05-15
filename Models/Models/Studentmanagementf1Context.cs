using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Models.Models;

public partial class Studentmanagementf1Context : DbContext
{
    public Studentmanagementf1Context()
    {
    }

    public Studentmanagementf1Context(DbContextOptions<Studentmanagementf1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DBDefault");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.MajorId).HasName("PK_Major_MajorID");

            entity.ToTable("Major");

            entity.HasIndex(e => e.MajorName, "UQ__Major__5FF4A37B2B190EA7").IsUnique();

            entity.Property(e => e.MajorId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MajorID");
            entity.Property(e => e.MajorName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Seq).HasName("PK__Room__CA1938C0CF13A287");

            entity.ToTable("Room");

            entity.HasIndex(e => e.Seq, "UQ__Room__CA1938C1AB058AEC").IsUnique();

            entity.Property(e => e.Seq).HasColumnName("SEQ");
            entity.Property(e => e.RoomName)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StuId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Stu_ID");
            entity.Property(e => e.TeaId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Tea_ID");

            entity.HasOne(d => d.Stu).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.StuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Room__Stu_ID__412EB0B6");

            entity.HasOne(d => d.Tea).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.TeaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Room__Tea_ID__4222D4EF");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Student_StudentID");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("StudentID");
            entity.Property(e => e.Mid)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MID");
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.MidNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Mid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__MID__398D8EEE");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF259443EC08628");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TeacherID");
            entity.Property(e => e.TeacherName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
