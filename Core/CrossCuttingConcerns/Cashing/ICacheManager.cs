namespace Core.CrossCuttingConcerns.Cashing
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string Key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
