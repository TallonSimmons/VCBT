namespace VacoBuiltCodeTest.Core.Contracts
{
    public interface IReadRepository<T>
    {
        Task<IQueryable<T>> GetAll();
    }
}
