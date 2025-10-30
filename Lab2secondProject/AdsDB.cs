namespace Lab2secondProject
{
    using Microsoft.EntityFrameworkCore;

    class AdsDb : DbContext
    {
        public AdsDb(DbContextOptions<AdsDb> options)
            : base(options) { }

        public DbSet<Ads> Advertisements => Set<Ads>();

        public DbSet<Sellers> Sellers => Set<Sellers>();
        public DbSet<Categories> Categories => Set<Categories>();
    }
}
