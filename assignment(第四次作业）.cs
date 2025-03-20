using System;

public class LinkedList<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public void Add(T data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }
    }

    public void ForEach(Action<T> action)
    {
        Node current = head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        // 打印元素
        Console.WriteLine("Elements:");
        list.ForEach(x => Console.WriteLine(x));

        // 求最大值、最小值和求和
        int max = int.MinValue;
        list.ForEach(x => { if (x > max) max = x; });
        Console.WriteLine($"Max: {max}");

        int min = int.MaxValue;
        list.ForEach(x => { if (x < min) min = x; });
        Console.WriteLine($"Min: {min}");

        int sum = 0;
        list.ForEach(x => sum += x);
        Console.WriteLine($"Sum: {sum}");
    }
}











using System;
using System.Threading;

public class AlarmClock1
{
    public event EventHandler Tick;
    public event EventHandler Alarm;

    public DateTime AlarmTime { get; set; }

    public void Start()
    {
        new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(1000);
                Tick?.Invoke(this, EventArgs.Empty);
                if (DateTime.Now >= AlarmTime)
                {
                    Alarm?.Invoke(this, EventArgs.Empty);
                    break;
                }
            }
        }).Start();
    }
}

class Program
{
    static void Main()
    {
        var clock = new AlarmClock1();
        clock.AlarmTime = DateTime.Now.AddSeconds(5);
        clock.Tick += (s, e) => Console.WriteLine($"[Tick] {DateTime.Now.ToString("HH:mm:ss")}");
        clock.Alarm += (s, e) => Console.WriteLine($"[Alarm] Time's up at {DateTime.Now.ToString("HH:mm:ss")}!");
        clock.Start();
        Console.ReadLine();
    }
}