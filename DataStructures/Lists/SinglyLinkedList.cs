namespace DataStructures.Lists;

public class SinglyLinkedList<T>(SinglyLinkedListNode<T> head)
{
    public SinglyLinkedListNode<T> Head { get; set; } = head;

    public void Reverse()
    {
        var current = head;
        var last = default(SinglyLinkedListNode<T>?);

        while (current is not null)
        {
            var next = current.Next;
            current.Next = last;
            last = current;
            current = next;
        }

        Head = last ?? throw new InvalidOperationException();
    }
}

public class SinglyLinkedListNode<T>(T data)
{
    public T Data { get; set; } = data;
    public SinglyLinkedListNode<T>? Next { get; set; }
}