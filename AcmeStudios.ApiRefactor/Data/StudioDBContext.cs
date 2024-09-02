using AcmeStudios.ApiRefactor.DAL.Entities;
using AcmeStudios.ApiRefactor.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace AcemStudios.ApiRefactor.Data
{
    public class StudioDBContext : DbContext
    {
        public DbSet<StudioItem> StudioItems { get; set; }
        public DbSet<StudioItemType> StudioItemTypes { get; set; }
        public StudioDBContext(DbContextOptions<StudioDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudioItem>()
            .HasOne(s => s.StudioItemType)
            .WithMany(ad => ad.StudioItem)
            .HasForeignKey(ad => ad.StudioItemTypeId);

            modelBuilder.Entity<StudioItemType>().HasData(
            new StudioItemType { StudioItemTypeId = 1, Value = "Synthesiser" },
            new StudioItemType { StudioItemTypeId = 2, Value = "Drum Machine" },
            new StudioItemType { StudioItemTypeId = 3, Value = "Effect" },
            new StudioItemType { StudioItemTypeId = 4, Value = "Sequencer" },
            new StudioItemType { StudioItemTypeId = 5, Value = "Mixer" },
            new StudioItemType { StudioItemTypeId = 6, Value = "Oscillator" },
            new StudioItemType { StudioItemTypeId = 7, Value = "Utility" }
            );
        }
    }
}
