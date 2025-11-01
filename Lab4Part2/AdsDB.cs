namespace Lab4Part2
{
    using Microsoft.EntityFrameworkCore;

    public class AdsDB : DbContext
    {
        public AdsDB(DbContextOptions<AdsDB> options)
            : base(options) { }

        public DbSet<Ads> Advertisements => Set<Ads>();

        public DbSet<Sellers> Sellers => Set<Sellers>();
        public DbSet<Categories> Categories => Set<Categories>();
    }
}
