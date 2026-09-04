using System.Collections;

namespace Section10_CustomLinkedList;

// https://docs.google.com/document/d/1o8Xyy_6WhpQjKWs80YvkxSpb0aaibmriwrgCgeMikiY/
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello, World! From Custom Linked List");
    }
}

public interface ICustomNode<T>
{
    public T Value { get; set; }
    public ICustomNode<T>? Previous { get; set; }
    public ICustomNode<T>? Next { get; set; }
}

public interface ICustomLinkedList<T> : ICollection<T>
{
    public void AddToFront(T item);
    public void AddToEnd(T item);
}

public class CustomNode<T> : ICustomNode<T>
{
    public CustomNode(T value)
    {
        this.Value = value;
    }


    public T Value { get; set; }
    public ICustomNode<T>? Previous { get; set; }
    public ICustomNode<T>? Next { get; set; }


    public override string ToString()
    {
        return this.Value?.ToString() ?? "";
    }
}

public class CustomLinkedList<T> : ICustomLinkedList<T>
{
    private ICustomNode<T>? _head;
    private ICustomNode<T>? _tail;

    public IEnumerator<T> GetEnumerator()
    {
        return this.GetNodes().Select(node => node.Value).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Add(T item)
    {
        this.Add(item, Position.End);
    }

    public void Clear()
    {
        for (ICustomNode<T>? currentNode = this._head; currentNode != null;)
        {
            (currentNode, currentNode.Next, currentNode.Previous) = (currentNode.Next, null, null);
        }

        this._head = null;
        this._tail = null;
    }

    public bool Contains(T item)
    {
        return this.GetNodes().Select(node => node.Value).Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(arrayIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(
            arrayIndex + this.Count,
            array.Length,
            $"{nameof(array)}, {nameof(arrayIndex)}"
        );

        int indexOffset = 0;
        foreach (ICustomNode<T> node in this.GetNodes())
        {
            (array[arrayIndex + indexOffset], indexOffset) = (node.Value, indexOffset + 1);
        }
    }

    public bool Remove(T item)
    {
        ICustomNode<T>? foundNode = this
            .GetNodes()
            .FirstOrDefault(node => node.Value != null && node.Value.Equals(item));
        if (foundNode is null)
        {
            return false;
        }


        ICustomNode<T>? previousNode = foundNode.Previous;
        ICustomNode<T>? nextNode = foundNode.Next;

        // node is both head and tail
        if (previousNode is null && nextNode is null)
        {
            this._head = null;
            this._tail = null;

            return true;
        }

        // node is head
        if (previousNode is null && nextNode is not null)
        {
            this._head = null;
            nextNode.Previous = null;
            foundNode.Next = null;

            return true;
        }

        // node is tail
        if (nextNode is null && previousNode is not null)
        {
            this._tail = previousNode;
            previousNode.Next = null;
            foundNode.Previous = null;

            return true;
        }

        // node is neither head nor tail
        if (previousNode is not null && nextNode is not null)
        {
            previousNode.Next = nextNode;
            nextNode.Previous = previousNode;
            foundNode.Previous = null;
            foundNode.Next = null;

            return true;
        }

        throw new InvalidOperationException();
    }

    public int Count => this.GetNodes().Count();

    public bool IsReadOnly => false;

    public void AddToFront(T item)
    {
        this.Add(item, Position.Front);
    }

    public void AddToEnd(T item)
    {
        this.Add(item, Position.End);
    }

    private IEnumerable<ICustomNode<T>> GetNodes()
    {
        for (
            ICustomNode<T>? currentNode = this._head;
            currentNode != null;
            currentNode = currentNode.Next)
        {
            yield return currentNode;
        }
    }

    private void Add(T item, Position position)
    {
        CustomNode<T> newNode = new(item);

        // Empty
        if (this._head is not { } previousHead || this._tail is not { } previousTail)
        {
            this._head = newNode;
            this._tail = newNode;
            return;
        }

        if (position == Position.Front)
        {
            this._head = newNode;
            previousHead.Previous = newNode;
            newNode.Next = previousHead;
        }

        if (position == Position.End)
        {
            this._tail = newNode;
            previousTail.Next = newNode;
            newNode.Previous = previousTail;
        }
    }

    private enum Position
    {
        Front = 1,
        End
    }
}