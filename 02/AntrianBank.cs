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
            throw new InvalidOperationException("Antrian kosong");
        }

        int result = front.Data;
        front = front.Next;
        if (front == null)
        {
            rear = null;
        }
        return result;
    }

    public bool IsEmpty()
    {
        return front == null;
    }
}
class AntrianBank
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        CustomQueue queue = new CustomQueue();

        for (int i = 0; i < N; i++)
        {
            string[] parts = Console.ReadLine().Split();

            if (parts[0] == "MASUK")
            {
                int x = int.Parse(parts[1]);
                queue.Enqueue(x);
            }
            else if (parts[0] == "LAYANI")
            {
                if (!queue.IsEmpty())
                {
                    Console.WriteLine(queue.Dequeue());
                }
                else
                {
                    Console.WriteLine("KOSONG");
                }
            }
        }
    }
}

