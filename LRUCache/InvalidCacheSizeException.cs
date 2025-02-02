namespace LRUCache
{
    /// <summary>
    /// An exception thrown when the LRU cache is instantiated with a capacity less than 1
    /// </summary>
    public class InvalidCacheCapacityException : Exception
    {
        public InvalidCacheCapacityException(string message) : base(message)
        {
        }
    }
}
