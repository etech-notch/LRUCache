# LRUCache

This is a design and implementation of an LRU (Least Recently Used) Cache in C# using Dictionary and LinkedList.

A Least Recently Used (LRU) Cache organizes items in order of use, allowing you to quickly identify which item hasn't been used for the longest amount of time.

It defines the process to evict items from a cache to make room for a new item when the cache reaches its capacity, by removing the least recently used item first.

The cache support:

- Get(int key): Retrieves the value of the key if it exists, otherwise returns -1.
- Put(int key, int value): Inserts a new key-value pair into the cache. If the cache reaches its capacity, remove the least recently used item.
- The operations should run in O(1) time complexity.

## How to use it

```cs
    var capacity = 3; //It will keep 3 most used keys.

    LRUCache cache = new LRUCache(2);
    cache.Put(1, 1);
    cache.Put(2, 2);
    Console.WriteLine(cache.Get(1)); // Returns 1
    cache.Put(3, 3); // Removes key 2
    Console.WriteLine(cache.Get(2)); // Returns -1 (not found)
```

## Recommended IDE

    Visual Studio 2022

## Installation

    1. Install the .Net 8.0.405 SDK https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.405-windows-x64-installer

    2. Restore Nuget packages for the solution

## Run

    Set the LRUCache as the startup project to run the App.
