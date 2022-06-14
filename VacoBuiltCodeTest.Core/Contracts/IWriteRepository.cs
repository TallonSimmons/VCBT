namespace VacoBuiltCodeTest.Core.Contracts
{
    public interface IWriteRepository<T>
    {
        Task<T> CreateAsync(T value);
        Task<T> UpdateAsync(T value);
    }
}
