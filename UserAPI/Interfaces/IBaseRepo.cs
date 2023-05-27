namespace UserAPI.Interfaces
{
    public interface IBaseRepo<K,T>
    {
        T Add(T item);
        T Get(K key);
    }
}
