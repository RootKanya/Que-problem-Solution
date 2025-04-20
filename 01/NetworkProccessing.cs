using System;

class ArrayQueue
{
    private int[] data;
    private int A01; 
    private int A;   
    private int B;   
    public int Capacity { get; }

    public ArrayQueue(int capacity)
    {
        Capacity = capacity;
        data = new int[capacity];
        A01 = 0;
        A = 0;
        B = 0;
    }

    public bool IsEmpty()
    {
        return B == 0;
    }

    public bool IsFull()
    {
        return B == Capacity;
    }

    public void Enqueue(int value)
    {
        if (IsFull()) return;
        data[A] = value;
        A = (A + 1) % Capacity;
        B++;
    }

    public int Dequeue()
    {
        if (IsEmpty()) return -1;
        int value = data[A01];
        A01 = (A01 + 1) % Capacity;
        B--;
        return value;
    }

    public int Peek()
    {
        if (IsEmpty()) return -1;
        return data[A01];
    }

    public int Count()
    {
        return B;
    }
}

class Program
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int M = int.Parse(firstLine[0]);
        int N = int.Parse(firstLine[1]);

        string[] capacities = Console.ReadLine().Split();
        string[] policies = Console.ReadLine().Split();

        ArrayQueue[] queues = new ArrayQueue[M];
        int[] overflowPolicies = new int[M];

        for (int i = 0; i < M; i++)
        {
            queues[i] = new ArrayQueue(int.Parse(capacities[i]));
        }

        for (int i = 0; i < M; i++)
        {
            overflowPolicies[i] = int.Parse(policies[i]);
        }

        int dropped = 0;

        for (int i = 0; i < N; i++)
        {
            string[] op = Console.ReadLine().Split();
            int type = int.Parse(op[0]);

            if (type == 1)
            {
                int X = int.Parse(op[1]) - 1;
                int V = int.Parse(op[2]);

                int curr = X;
                bool inserted = false;
                while (curr != -1)
                {
                    if (!queues[curr].IsFull())
                    {
                        queues[curr].Enqueue(V);
                        inserted = true;
                        break;
                    }
                    curr = overflowPolicies[curr] - 1;
                }

                if (!inserted)
                {
                    dropped++;
                }
            }
            else if (type == 2)
            {
                int X = int.Parse(op[1]) - 1;
                int result = queues[X].Dequeue();
                Console.WriteLine(result);
            }
            else if (type == 3)
            {
                int X = int.Parse(op[1]) - 1;
                int Y = int.Parse(op[2]);
                System.Collections.Generic.List<int> transferred = new System.Collections.Generic.List<int>();

                for (int j = 0; j < Y; j++)
                {
                    if (queues[X].IsEmpty()) break;
                    int value = queues[X].Dequeue();

                    int curr = X;
                    bool inserted = false;
                    while (curr != -1)
                    {
                        if (!queues[curr].IsFull())
                        {
                            queues[curr].Enqueue(value);
                            inserted = true;
                            transferred.Add(value);
                            break;
                        }
                        curr = overflowPolicies[curr] - 1;
                    }

                    if (!inserted)
                    {
                        dropped++;
                    }
                }

                Console.Write("[");
                for (int j = 0; j < transferred.Count; j++)
                {
                    if (j > 0) Console.Write(", ");
                    Console.Write(transferred[j]);
                }
                Console.WriteLine("]");
            }
        }

        Console.WriteLine(dropped);
    }
}
