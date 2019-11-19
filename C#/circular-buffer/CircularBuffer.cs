using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    // variables and properties
    Queue<T> numbers;
    public int Used { get; set; }
    public int Capacity { get; private set; }

    // constructor
    public CircularBuffer(int capacity)
    {
        Capacity = capacity;
        Clear();
    }

    // returns first element in queue
    public T Read()
    {
        if (Used == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        Used--;
        return numbers.Dequeue();
    }

    // if room, adds element to end of queue
    public void Write(T value)
    {
        if (Used < Capacity)
        {
            numbers.Enqueue(value);
            Used++;
        }
        else
        {
            throw new InvalidOperationException("Queue is full");
        }
    }

    // add element to end of queue. if needed, removes and element from front
    public void Overwrite(T value)
    {
        if (Used == Capacity)
        {
            T temp = numbers.Dequeue();
            Used--;
        }
        Write(value);
    }

    // creates new queue 
    public void Clear()
    {
        numbers = new Queue<T>(Capacity);
        Used = 0;
    }
}