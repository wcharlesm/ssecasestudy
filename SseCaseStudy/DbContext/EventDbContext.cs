using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SseCaseStudy.Models.EventModels;

namespace SseCaseStudy.DbContext
{
    public class EventDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<MediaItemClickEvent> MediaItemClickEvent { get; set; }
        public DbSet<SearchEvent> SearchEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaItemClickEvent>()
                .ToTable("MediaItemClickEvent")
                .HasOne(m => m.SearchEvent)
                .WithMany(s => s.MediaItemClickEvents)
                .HasForeignKey(m => m.SearchId);

            modelBuilder.Entity<SearchEvent>().ToTable("SearchEvent").HasKey(s => s.SearchId);
        }
    }
}
