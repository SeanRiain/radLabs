namespace Lab2secondProject
{
    using Microsoft.EntityFrameworkCore;

    class AdsDb : DbContext
    {
        public AdsDb(DbContextOptions<AdsDb> options)
            : base(options) { }

        public DbSet<Ads> Advertisements => Set<Ads>();
    }
}
