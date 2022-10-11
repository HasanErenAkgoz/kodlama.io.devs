using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.Context
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguages> programmingLanguages { get; set; }
        public DbSet<LanguageTech> languageTeches { get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //   base.OnConfiguring(
            //       optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaioDevsConnectionString")));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguages>(a =>
            {
                a.ToTable("programmingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            });

            modelBuilder.Entity<LanguageTech>(a =>
            {
                a.ToTable("languageTeches").HasKey(k => k.Id);
                a.Property(p => p.Name);
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<SocialMedia>(a =>
            {
                a.ToTable("socialMedias").HasKey(k => k.Id);
                a.Property(p => p.Name);
                a.Property(p => p.Url);
                a.Property(p => p.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            });


        }

    }
}
