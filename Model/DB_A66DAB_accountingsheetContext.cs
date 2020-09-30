using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ACCOUNTINGSHEET.Model
{
    public partial class DB_A66DAB_accountingsheetContext : DbContext
    {
        public DB_A66DAB_accountingsheetContext()
        {
        }

        public DB_A66DAB_accountingsheetContext(DbContextOptions<DB_A66DAB_accountingsheetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<Monthlyinput> Monthlyinput { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Projecttype> Projecttype { get; set; }
        public virtual DbSet<RefreshTokens> RefreshTokens { get; set; }
        public virtual DbSet<Taskcost> Taskcost { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-R9RNT2J\\SQLEXPRESS;Database=DB_A66DAB_accountingsheet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("contractor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(225);
            });

            modelBuilder.Entity<Monthlyinput>(entity =>
            {
                entity.ToTable("monthlyinput");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contractorid).HasColumnName("contractorid");

                entity.Property(e => e.Createdat)
                    .HasColumnName("createdat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Expenseamount)
                    .HasColumnName("expenseamount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Incomeamount)
                    .HasColumnName("incomeamount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Inputtype).HasColumnName("inputtype");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(250);

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Taskcostid).HasColumnName("taskcostid");

                entity.Property(e => e.Updatedat)
                    .HasColumnName("updatedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(225);

                entity.Property(e => e.Ordernumber).HasColumnName("ordernumber");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Projecttype>(entity =>
            {
                entity.ToTable("projecttype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<RefreshTokens>(entity =>
            {
                entity.HasKey(e => e.RefreshTokenId);

                entity.ToTable("refreshTokens");

                entity.Property(e => e.RefreshTokenId)
                    .HasColumnName("refreshTokenId")
                    .HasMaxLength(250);

                entity.Property(e => e.ClientId)
                    .HasColumnName("clientId")
                    .HasMaxLength(250);

                entity.Property(e => e.ExpiresUtc).HasColumnType("datetime");

                entity.Property(e => e.IssuedUtc).HasColumnType("datetime");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_refreshTokens_token");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_refreshTokens_user");
            });

            modelBuilder.Entity<Taskcost>(entity =>
            {
                entity.ToTable("taskcost");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(225);
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("token");

                entity.Property(e => e.ClientId)
                    .HasColumnName("clientId")
                    .HasMaxLength(250);

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AllowedOrigin)
                    .HasColumnName("allowedOrigin")
                    .HasMaxLength(250);

                entity.Property(e => e.ApplicationType).HasColumnName("applicationType");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.RefreshTokenLifeTime).HasColumnName("refreshTokenLifeTime");

                entity.Property(e => e.Secret)
                    .HasColumnName("secret")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150);

                entity.Property(e => e.Emailactivated).HasColumnName("emailactivated");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobileactivated).HasColumnName("mobileactivated");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(150);

                entity.Property(e => e.Updatedat)
                    .HasColumnName("updatedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
