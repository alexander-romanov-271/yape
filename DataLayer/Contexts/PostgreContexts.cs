using Microsoft.EntityFrameworkCore;
using newyape.DataLayer.Models;

namespace newyape.DataLayer.Contexts;
public sealed class ApplicationContext : DbContext
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();

    public DbSet<GuidelineEntity> Guidelines => Set<GuidelineEntity>();

    public DbSet<RuleEntity> Rules => Set<RuleEntity>();

    public DbSet<FieldEntity> Fields => Set<FieldEntity>();

    public DbSet<UserEntity> Users => Set<UserEntity>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
    {
        Database.EnsureCreated();
    }
    
    public ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => {builder.AddConsole(); });

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ProductEntity>().HasKey(p => p.Id);
        builder.Entity<ProductEntity>().
            HasMany(p => p.Guideline).
            WithMany(g => g.Product);
        

        builder.Entity<GuidelineEntity>().HasKey(g => g.Id);
        builder.Entity<GuidelineEntity>().
            HasMany(g => g.Product).
            WithMany(p => p.Guideline);
        
        builder.Entity<GuidelineEntity>().
            HasMany(g => g.Rule).
            WithMany(r => r.Guideline);
        
        builder.Entity<RuleEntity>().HasKey(r => r.Id);
        builder.Entity<RuleEntity>().
            HasMany(r => r.Guideline).
            WithMany(g => g.Rule);
        
        builder.Entity<RuleEntity>().
            HasOne(r => r.Field).
            WithMany(f => f.Rule).
            HasForeignKey(r => r.FieldId);
            
        builder.Entity<FieldEntity>().HasKey(f => f.Id);
        builder.Entity<FieldEntity>().
            HasMany(f => f.Rule).
            WithOne(r => r.Field);

        builder.Entity<UserEntity>().HasKey(u => u.Id);
    }
}

