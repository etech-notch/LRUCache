namespace LRUCache
{
    public class LRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, int> _cache;
        private readonly LinkedList<int> _list;
        private readonly Dictionary<int, LinkedListNode<int>> _nodesMap;

        public LRUCache(int capacity)
        {
            // checks if the cache capacity is less then 1
            // if true throw InvalidCacheSizeException
            if (capacity < 1)
            {
                throw new InvalidCacheCapacityException("Cache capacity must be greater than 0");
            }

            _capacity = capacity;
            _cache = new Dictionary<int, int>();
            _list = new LinkedList<int>();
            _nodesMap = new Dictionary<int, LinkedListNode<int>>();
        }


        /// <summary>
        /// Retrieves the value of the key if it exists, otherwise returns -1.
        /// </summary>
        public int Get(int key)
        {
            // check if the cache contains the key
            if (_cache.ContainsKey(key))
            {
                // then make the key the most recently used one
                var node = _nodesMap[key];
                _list.Remove(node);
                _list.AddFirst(node);

                // retrieve the cached item value
                return _cache[key];
            }
            else
            {
                // otherwise returns -1
                return -1;
            }
        }

        /// <summary>
        /// Upserts key-value pair item to cache.
        /// </summary>
        public void Put(int key, int value)
        {
            // checks if an item with the key exists in cache
            if (_cache.ContainsKey(key))
            {
                // update item using the key the value
                _cache[key] = value;

                // then make the key the most recently used one
                var node = _nodesMap[key];
                _list.Remove(node);
                _list.AddFirst(node);
            }
            else
            {
                // check if the cache has reached its capacity
                if (_list.Count == _capacity)
                {
                    // remove the last node from the node map.
                    _nodesMap.Remove(_list.Last!.Value);

                    // also remove the corresponding item from cache
                    _cache.Remove(_list.Last.Value);

                    // then remove the least recently used item from the list
                    _list.RemoveLast();
                }

                // add key-value pair item to the cache.
                _cache.Add(key, value);

                // create a node for the item
                var newNode = new LinkedListNode<int>(key);

                // then make the key the most recently used one
                _list.AddFirst(newNode);

                // now add created node item to the nodes map, to optimize performance
                _nodesMap.Add(key, newNode);            
            }
        }
    }
}
