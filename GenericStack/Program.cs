using System;

// README.md를 읽고 아래에 코드를 작성하세요.

class SimpleQueue<T>
{
    private T[] items;
    private int head;
    private int tail;
    private int capacity;

    public int Count { get; private set; }
    public bool IsFull => Count == capacity;
    public bool IsEmpty => Count == 0;

    public SimpleQueue(int capacity)
    {
        this.capacity = capacity;
        items = new T[capacity];
        head = 0;
        tail = 0;
        Count = 0;
    }

    public void Enqueue(T item)
    {
        if (IsFull)
        {
            Console.WriteLine("큐가 가득 찼습니다.");
            return;
        }
        items[tail] = item;
        tail = (tail + 1) % capacity;
        Count++;
    }

    public T Dequeue()
    {
        if (IsEmpty)
        {
            Console.WriteLine("큐가 비어있습니다.");
            return default(T);
        }
        T item = items[head];
        head = (head + 1) % capacity;
        Count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty)
        {
            Console.WriteLine("큐가 비어있습니다.");
            return default(T);
        }
        return items[head];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== int 큐 (용량: 3) ===");
        SimpleQueue<int> intQueue = new SimpleQueue<int>(3);
        intQueue.Enqueue(10);
        intQueue.Enqueue(20);
        intQueue.Enqueue(30);
        Console.WriteLine("Enqueue: 10, 20, 30");
        Console.WriteLine($"Count: {intQueue.Count}, IsFull: {intQueue.IsFull}");
        intQueue.Enqueue(40);
        Console.WriteLine($"Peek: {intQueue.Peek()}");
        Console.WriteLine($"Dequeue: {intQueue.Dequeue()}");
        Console.WriteLine($"Dequeue: {intQueue.Dequeue()}");
        Console.WriteLine($"Count: {intQueue.Count}, IsEmpty: {intQueue.IsEmpty}");

        Console.WriteLine();
        Console.WriteLine("=== string 큐 (용량: 2) ===");
        SimpleQueue<string> strQueue = new SimpleQueue<string>(2);
        strQueue.Enqueue("Hello");
        strQueue.Enqueue("World");
        Console.WriteLine("Enqueue: Hello, World");
        Console.WriteLine($"Dequeue: {strQueue.Dequeue()}");
        Console.WriteLine($"Dequeue: {strQueue.Dequeue()}");
        Console.WriteLine($"Dequeue: {strQueue.Dequeue()}");
        Console.WriteLine($"IsEmpty: {strQueue.IsEmpty}");
    }
}