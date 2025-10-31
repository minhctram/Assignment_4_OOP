using System;
using System.Collections.Generic;

// ===========================
// GENERIC STACK CLASS
// ===========================
public class MyStack<T>
{
    private List<T> _items = new List<T>(); // Internal storage

    // 1. Count() - returns number of elements in stack
    public int Count()
    {
        return _items.Count;
    }

    // 2. Push(T item) - adds item to top of stack
    public void Push(T item)
    {
        _items.Add(item);
    }

    // 3. Pop() - removes and returns top item
    public T Pop()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Stack is empty.");

        // Get the last item
        int lastIndex = _items.Count - 1;
        T item = _items[lastIndex];

        // Remove it
        _items.RemoveAt(lastIndex);

        return item;
    }
}

// ===========================
// DEMO PROGRAM
// ===========================
class Program
{
    static void Main()
    {
        // Stack of integers
        MyStack<int> intStack = new MyStack<int>();
        intStack.Push(10);
        intStack.Push(20);
        intStack.Push(30);

        Console.WriteLine("Integer Stack Count: " + intStack.Count());
        Console.WriteLine("Popped: " + intStack.Pop());
        Console.WriteLine("New Count: " + intStack.Count());

        // Stack of strings
        MyStack<string> stringStack = new MyStack<string>();
        stringStack.Push("Apple");
        stringStack.Push("Banana");
        stringStack.Push("Cherry");

        Console.WriteLine("\nString Stack Count: " + stringStack.Count());
        Console.WriteLine("Popped: " + stringStack.Pop());
        Console.WriteLine("New Count: " + stringStack.Count());
    }
}