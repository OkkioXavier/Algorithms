namespace DataStructures.Heaps;

public class PriorityHeap<T>
{
    private readonly Func<T, T, bool> _hasHigherPriority;
    private readonly T[] _heap;
    private int _count;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="items"></param>
    /// <param name="hasHigherPriority">Should return true if the first argument is the minimum</param>
    public PriorityHeap(T[] items, Func<T, T, bool> hasHigherPriority)
    {
        _hasHigherPriority = hasHigherPriority;
        _count = items.Length;
        _heap = items;
        Heapify();
    }

    public T PeekTop()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }
        
        return _heap[0];
    }

    public T Pop()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }
        
        var min = _heap[0];
        _heap[0] = _heap[_count - 1];
        _count--;
        Heapify();

        return min;
    }

    void Heapify()
    {
        var index = _count - 1;

        while (index >= 0)
        {
            BubbleDown(index);
            index--;
        }
    }

    private void BubbleDown(int index)
    {
        var minIndex = index;
        var leftChildIndex = (index + 1) * 2 - 1;
        var rightChildIndex = (index + 1) * 2;

        if (leftChildIndex < _count && _hasHigherPriority(_heap[leftChildIndex], _heap[index]))
        {
            minIndex = leftChildIndex;
        }

        if (rightChildIndex < _count && _hasHigherPriority(_heap[rightChildIndex], _heap[minIndex]))
        {
            minIndex = rightChildIndex;
        }

        if (minIndex != index)
        {
            (_heap[index], _heap[minIndex]) = (_heap[minIndex], _heap[index]);
            BubbleDown(minIndex);
        }
    }
}