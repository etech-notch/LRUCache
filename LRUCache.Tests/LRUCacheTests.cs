namespace LRUCache.Tests;

public class LRUCacheTests
{
    [Fact]
    public void Should_Return_InvalidCacheCapacityException_When_Capacity_Is_Invalid()
    {
        var capacity = 0;
        var ex = Assert.Throws<InvalidCacheCapacityException>(() => new LRUCache(capacity));
        Assert.Equal("Cache capacity must be greater than 0", ex.Message);
    }

    [Fact]
    public void Should_Return_Expected_Value()
    {
        var cache = new LRUCache(2);
        cache.Put(1, 1);
        Assert.Equal(1, cache.Get(1));
    }

    [Fact]
    public void Should_Remove_Least_Recently_Used_From_Cache_When_Capacity_Is_Reached()
    {
        var cache = new LRUCache(2);

        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Put(3, 3);

        Assert.Equal(-1, cache.Get(1));
    }
}