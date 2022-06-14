namespace VacoBuiltCodeTest.Core.Contracts
{
    public interface IWriteRepository<T>
    {
        Task<T> SaveAsync(T value);
    }
}
