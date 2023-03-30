using TNE.Domain.Entities;

namespace TNE.Domain;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Returns remote objects only
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    IQueryable<T> Get<T>() where T : Entity;

    /// <summary>
    /// Executes .Where clause on local and remote sets and returns union of results
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="predicate">Selector for .Where clause</param>
    /// <returns>Union of results</returns>
    IEnumerable<T> Where<T>(Func<T, bool> predicate) where T : Entity;

    T Attach<T>(T entity) where T : Entity;
    void Attach<T>(T[] entities) where T : Entity;

    void Add<T>(T entity) where T : Entity;
    void Remove<T>(T entity) where T : Entity;

    Task<int> Commit();

    Task<int> Execute(string sql);
}