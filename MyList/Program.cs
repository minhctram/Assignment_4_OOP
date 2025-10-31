using System;

public class MyList<T>
{
    private T[] items;
    private int count;

    public MyList()
    {
        items = new T[4];
        count = 0;
    }

    public void Add(T element)
    {
        if (count == items.Length)
        {
            Resize();
        }
        items[count++] = element;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));
        
        T removed = items[index];
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        count--;
        return removed;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i].Equals(element))
                return true;
        }
        return false;
    }

    public void Clear()
    {
        count = 0;
        items = new T[4];
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (count == items.Length)
        {
            Resize();
        }

        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }

        items[index] = element;
        count++;
    }
    
    public void DeleteAt(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));

        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }

        count--;
    }

    public T Find(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return items[index];
    }

    private void Resize()
    {
        T[] newItems = new T[items.Length * 2];
        for (int i = 0; i < items.Length; i++)
        {
            newItems[i] = items[i];
        }
        items = newItems;
    }

    public int Count => count;
}

class Program
{
    static void Main()
    {
        MyList<int> numbers = new MyList<int>();

        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
        Console.WriteLine("List contains 20: " + numbers.Contains(20));

        numbers.InsertAt(15, 1);
        Console.WriteLine("Item at index 1: " + numbers.Find(1));

        numbers.DeleteAt(2);
        Console.WriteLine("After delete, count = " + numbers.Count);

        int removed = numbers.Remove(1);
        Console.WriteLine("Removed item: " + removed);

        numbers.Clear();
        Console.WriteLine("After clear, count = " + numbers.Count);
    }
}
