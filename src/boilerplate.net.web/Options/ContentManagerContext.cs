using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Contentful.Models
{
    public partial class ContentManagerContext : DbContext
    {
        public ContentManagerContext()
        {
        }

        public ContentManagerContext(DbContextOptions<ContentManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CampaignConfiguration> CampaignConfiguration { get; set; }
        public virtual DbSet<CampaignType> CampaignType { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        // Unable to generate entity type for table 'dbo.PersonCampaignConfigurationMap'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:vbcontentmanager.database.windows.net,1433;Initial Catalog=ContentManager;Persist Security Info=False;User ID=bcoats;Password=is`$AWoLmPYzQtVunnga2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CampaignConfiguration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CampaignTypeId).HasColumnName("campaignTypeId");

                entity.Property(e => e.Keyword)
                    .IsRequired()
                    .HasColumnName("keyword")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CampaignType)
                    .WithMany(p => p.CampaignConfiguration)
                    .HasForeignKey(d => d.CampaignTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignConfiguration_CampaignType");
            });

            modelBuilder.Entity<CampaignType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaignType1)
                    .IsRequired()
                    .HasColumnName("campaignType")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(255);
            });
        }
    }
}
