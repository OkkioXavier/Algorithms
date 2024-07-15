namespace DataStructures;

public class HashMap<TKey, TValue>
{
    record KeyValue(TKey Key, TValue Value);
    
    private const int DefaultCapacity = 16;

    private List<KeyValue>?[] _items;

    private int _capacity;

    /// <summary>
    /// Sets the capacity of the HashMap
    /// Will set the next multiple of two if capacity is not even
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the new capacity is less than or equal to the old capacity</exception>
    public int Capacity
    {
        get => _capacity;
        set
        {
            if (value <= Capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "New capacity must be greater than current capacity");
            }

            var originalItems = _items;
            _items = new List<KeyValue>[value];
            _itemCount = 0;

            foreach (var item in originalItems)
            {
                if (item is not null)
                {
                    foreach (var entry in item)
                    {
                        this[entry.Key] = entry.Value;
                    }
                }
            }

            _capacity = value;
        }
    }

    private long _itemCount;
    private EqualityComparer<TKey> _equalityComparer = EqualityComparer<TKey>.Default;

    private long ItemCount
    {
        get => _itemCount;
        set
        {
            if (value / (double)_items.Length >= 0.75)
            {
                Capacity = _items.Length * 2;
            }

            _itemCount = value;
        }
    }

    private HashMap(int initialLength)
    {
        if (initialLength % 2 != 0)
        {
            initialLength *= 2;
        }

        _items = new List<KeyValue>[initialLength];
        _capacity = initialLength;
    }

    public HashMap() : this(16)
    {
    }

    public HashMap(IEnumerable<TValue> items, Func<TValue, TKey> keyGenerator) : this(Math.Max(DefaultCapacity,
        items.Count() * 2))
    {
        foreach (var item in items)
        {
            this[keyGenerator(item)] = item;
        }
    }

    public void Add(TKey key, TValue item)
    {
        if (Contains(key))
        {
            throw new ArgumentException("Keys already exists", nameof(key));
        }

        this[key] = item;
    }

    public bool Contains(TKey key)
    {
        var index = GetIndex(key);

        return _items[index]?.Any(i => EqualityComparer<TKey>.Default.Equals(i.Key, key)) == true;
    }

    public TValue? Remove(TKey key)
    {
        var index = GetIndex(key);

        var item = _items[index]?.SingleOrDefault(i => EqualityComparer<TKey>.Default.Equals(i.Key, key));

        if (item is { Value: not null } nonNullItem)
        {
            _items[index]?.Remove(nonNullItem);
            ItemCount--;
            return nonNullItem.Value;
        }

        return default;
    }

    public TValue this[TKey key]
    {
        get
        {
            var index = GetIndex(key);
            var item = _items[index]?.SingleOrDefault(i => EqualityComparer<TKey>.Default.Equals(i.Key, key));

            if (item is null)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "Key does not exist in dictionary");
            }

            return item.Value;
        }
        set
        {
            var index = GetIndex(key);

            _items[index] ??= [];

            var elementAt = _items[index]!.FindIndex(i => _equalityComparer.Equals(i.Key, key));

            if (elementAt >= 0)
            {
                _items[index]![elementAt] = new KeyValue(key, value);
            }
            else
            {
                _items[index]!.Insert(0, new KeyValue(key, value));
                ItemCount++;
            }
        }
    }

    private int GetIndex(TKey key)
    {
        ArgumentNullException.ThrowIfNull(key);
        return key.GetHashCode() & (_items.Length - 1);
    }
}