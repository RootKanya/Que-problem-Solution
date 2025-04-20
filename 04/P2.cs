using System;

class Program
{
    class MyQueue
    {
        private int[] queue;
        private int front, rear, capacity;

        public MyQueue(int capacity)
        {
            this.capacity = capacity;
            queue = new int[capacity];
            front = -1;
            rear = -1;
        }

        public bool IsEmpty()
        {
            return front == -1;
        }

        public bool IsFull()
        {
            return rear == capacity - 1;
        }

        public void Enqueue(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full, cannot add " + value);
                return;
            }
            if (front == -1)
                front = 0;
            queue[++rear] = value;
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return -1;
            }
            int dequeuedValue = queue[front];
            if (front >= rear)
                front = rear = -1;
            else
                front++;
            return dequeuedValue;
        }

        public void PrintQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            for (int i = front; i <= rear; i++)
            {
                Console.Write(queue[i] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int N = int.Parse(inputs[0]);
        int X = int.Parse(inputs[1]);
        int Y = int.Parse(inputs[2]);

        MyQueue queue = new MyQueue(N + Y);

        string[] numbers = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            queue.Enqueue(int.Parse(numbers[i]));
        }

        for (int i = 0; i < X; i++)
        {
            queue.Dequeue();
        }

        string[] newNumbers = Console.ReadLine().Split();
        for (int i = 0; i < Y; i++)
        {
            queue.Enqueue(int.Parse(newNumbers[i]));
        }

        queue.PrintQueue();

        Console.WriteLine($"Antrian {X} sudah ditangani dan bertambah {Y} antiran dengan angka {string.Join(" ", newNumbers)}.");
    }
}
