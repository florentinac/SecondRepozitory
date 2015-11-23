namespace MyOOP
{
    public interface IHash<T>
    {
        int GetHashCode(T obj);
    }
}