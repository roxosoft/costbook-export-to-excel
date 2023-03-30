using Microsoft.EntityFrameworkCore;
using TNE.Domain.EntityFrameworkV2.Mappings;

namespace TNE.Domain.EntityFrameworkV2;

public class UnitOfWork : DbContext, IUnitOfWork
{
    public UnitOfWork(DbContextOptions options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new DataRowConfiguration());
        modelBuilder.ApplyConfiguration(new CrewCompositionConfiguration());
        modelBuilder.ApplyConfiguration(new CrewConfiguration());
        modelBuilder.ApplyConfiguration(new LaborerConfiguration());
        modelBuilder.ApplyConfiguration(new SectionDescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new SectionKeywordConfiguration());
        modelBuilder.ApplyConfiguration(new UnitOfMeasureConfiguration());
        modelBuilder.ApplyConfiguration(new MaterialConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
        modelBuilder.ApplyConfiguration(new AggregateConfiguration());

        modelBuilder.ApplyConfiguration(new RowConfiguration());
        modelBuilder.ApplyConfiguration(new UnknownRowConfiguration());
        modelBuilder.ApplyConfiguration(new SectionRowConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentCostRowConfiguration());
        modelBuilder.ApplyConfiguration(new MaterialCostRowConfiguration());
        modelBuilder.ApplyConfiguration(new AggregateCostRowConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseCostRowConfiguration());
        modelBuilder.ApplyConfiguration(new TextRowConfiguration());
        modelBuilder.ApplyConfiguration(new RowImageConfiguration());

        modelBuilder.ApplyConfiguration(new AreaConfiguration());
        modelBuilder.ApplyConfiguration(new CostModificatorConfiguration());

        modelBuilder.ApplyConfiguration(new CustomCostRowConfiguration());

        modelBuilder.ApplyConfiguration(new AggregateCostRowMLETConfiguration());

        modelBuilder.ApplyConfiguration(new PageRowConfiguration());
    }

    IQueryable<T> IUnitOfWork.Get<T>()
    {
        return base.Set<T>();
    }

    T IUnitOfWork.Attach<T>(T entity)
    {
        var entry = base.Attach<T>(entity);

        return entry.Entity;
    }

    void IUnitOfWork.Attach<T>(T[] entities)
    {
        base.AttachRange(entities);
    }

    void IUnitOfWork.Add<T>(T entity)
    {
        base.Add(entity);
    }

    void IUnitOfWork.Remove<T>(T entity)
    {
        base.Remove(entity);
    }


    IEnumerable<T> IUnitOfWork.Where<T>(Func<T, bool> predicate)
    {
        var localResults = base.Set<T>().Local.Where(predicate);
        var remoteResults = base.Set<T>().Where(predicate);
        return localResults.Union(remoteResults);
    }


    public Task<int> Commit()
    {
        return base.SaveChangesAsync();
    }
    public Task<int> Execute(string sql)
    {
        return base.Database.ExecuteSqlRawAsync(sql); //Old - ExecuteSqlCommandAsync
    }
}