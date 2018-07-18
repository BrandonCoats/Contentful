using Contentful.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contentful.Options
{
    public class CampaignContext : DbContext
    {
        public DbSet<Person> person { get; set; }
        public DbSet<CampaignType> campaignType{ get; set; }
        public DbSet<CampaignContext> campaignContext { get; set; }
        public DbSet<CampaignConfiguration> campaignConfiguration { get; set; }
        public CampaignContext(DbContextOptions<CampaignContext> options): base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<CampaignConfiguration>(entity =>
            {
                entity.Property(e => e.CampaignType).IsRequired();
                entity.Property(e => e.Keyword).IsRequired();
            });
        }
    }
}
