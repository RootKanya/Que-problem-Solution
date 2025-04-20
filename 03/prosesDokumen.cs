using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class CustomQueue
{
    private Node front;
    private Node rear;

    public CustomQueue()
    {
        front = null;
        rear = null;
    }

    public void Enqueue(int data)
    {
        Node newNode = new Node(data);
        if (rear == null)
        {
            front = rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue kosong");
        }

        int result = front.Data;
        front = front.Next;
        if (front == null)
        {
            rear = null;
        }
        return result;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue kosong");
        }
        return front.Data;
    }

    public bool IsEmpty()
    {
        return front == null;
    }
}

class ProsesDokumen
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        CustomQueue regular = new CustomQueue();
        CustomQueue prioritas = new CustomQueue();

        for (int i = 0; i < N; i++)
        {
            string[] parts = Console.ReadLine().Split();

            if (parts[0] == "REGULAR")
            {
                int x = int.Parse(parts[1]);
                regular.Enqueue(x);
            }
            else if (parts[0] == "PRIORITAS")
            {
                int x = int.Parse(parts[1]);
                prioritas.Enqueue(x);
            }
            else if (parts[0] == "PROSES")
            {
                if (!prioritas.IsEmpty())
                {
                    Console.WriteLine(prioritas.Dequeue());
                }
                else if (!regular.IsEmpty())
                {
                    Console.WriteLine(regular.Dequeue());
                }
                else
                {
                    Console.WriteLine("TIDAK ADA DOKUMEN");
                }
            }
        }
    }
}
