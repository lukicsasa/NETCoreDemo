using Demo.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Entities
{
    public partial class DemoContext : DbContext
    {
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<User> User { get; set; }

        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Helper.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SubjectId });

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Subject");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });
        }
    }
}
