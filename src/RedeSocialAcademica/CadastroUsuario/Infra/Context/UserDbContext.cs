using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Models.Enums;
using CadastroUsuario.Infra.EnumConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.OpenApi.Extensions;

namespace CadastroUsuario.Infra.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<EducationalBackground> EducationalBackground { get; set; }
        public DbSet<Institution> Institution { get; set; }
        public DbSet<UserLockout> UserLockout { get; set; }
        public DbSet<ProfilePic> ProfilePics { get; set; }
        public DbSet<Links> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          

            modelBuilder.Entity<ApplicationUser>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.FullName)
                    .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.EMail)
                    .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Password)
                    .HasMaxLength(255)
                        .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Phone)
                    .HasMaxLength(30);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.BirthDate)
                    .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.EducationalDegree)
                    .HasMaxLength(30);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.ActualCourse)
                    .HasMaxLength(50);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Curriculum)
                    .HasMaxLength(10000);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Institution)
                    .HasMaxLength(100);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.ConsentPrivacyPolicy)
                    .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.ConsentCookies)
                    .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Password)
                    .IsRequired();

            modelBuilder.Entity<UserLockout>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<UserLockout>()
                .Property(b => b.LockoutDate)
                    .IsRequired();

            modelBuilder.Entity<UserLockout>()
                .Property(b => b.QtdMinutes)
                    .IsRequired();

            modelBuilder.Entity<Institution>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Institution>()
                .Property(i => i.Name)
                    .IsRequired()
                        .HasMaxLength(75);

            modelBuilder.Entity<Institution>()
                .Property(i => i.BrazilianCity)
                    .IsRequired()
                        .HasMaxLength(75);

            modelBuilder.Entity<Institution>()
                .Property(i => i.BrazilianState)
                    .IsRequired()
                        .HasMaxLength(2);

            modelBuilder.Entity<EducationalBackground>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<EducationalBackground>()
                .Property(f => f.Course)
                    .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<EducationalBackground>()
                .Property(f => f.EducationalDegree)
                    .HasMaxLength(30)
                        .IsRequired();

            modelBuilder.Entity<EducationalBackground>()
                .Property(f => f.Status)
                    .IsRequired()
                        .HasMaxLength(15);

            modelBuilder.Entity<EducationalBackground>()
                .Property(f => f.Institution)
                    .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<EducationalBackground>()
                .Property(f => f.CourseBegin)
                    .IsRequired();

            modelBuilder.Entity<EducationalBackground>()
                .Property(f => f.CourseEnd)
                    .IsRequired();

            modelBuilder.Entity<ProfilePic>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProfilePic>()
                .Property(p => p.FileNameAndPath)
                    .IsRequired();

            modelBuilder.Entity<ProfilePic>()
                .Property(p => p.DateCreation)
                    .IsRequired();

            modelBuilder.Entity<Links>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Links>()
                .Property(l => l.ProfileName)
                    .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Links>()
                .Property(l => l.Origin)
                    .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Links>()
                .Property(l => l.Link)
                    .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.UserLockouts)
                    .WithOne(b => b.User)
                        .HasForeignKey(b => b.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.EducationalBackgrounds)
                    .WithOne(f => f.User)
                        .HasForeignKey(f => f.UserId)
                            .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ProfilePictures)
                    .WithOne(p => p.User)
                        .HasForeignKey(p => p.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Links)
                    .WithOne(l => l.ApplicationUser)
                        .HasForeignKey(l => l.UserId)
                            .IsRequired()
                                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
