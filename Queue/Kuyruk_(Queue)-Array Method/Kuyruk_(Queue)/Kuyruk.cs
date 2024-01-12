using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Kuyruk__Queue_
{
    public class Kuyruk<T> : IQueue<T>
    {
        private T[] array;
        private int front;
        private int rear;
        private int count;

        public Kuyruk(int size)
        {
            array = new T[size];
            front = -1;
            rear = -1;
        }

        public Kuyruk() : this(10)
        {

        }

        public int Size()
        {
            return count;
        }

        public void enQueue(T item)
        {
            if (count == array.Length)
            {
                throw new InvalidOperationException("Kuyruk Dolu!");
            }
            array[++count] = item;
            if (count == 0)
            {
                front++;
            }
            count++;
        }
        public T deQueue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("queue is already empty");
            }
            T item = array[front++];
            if (front > rear)
            {
                front = -1;
                rear = -1;
            }
            count--;
            return item;
        }

        public bool contains(T item)
        {
            if (count == 0)
            {
                return false;
            }
            for (int i = front; i < rear; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public T access(int index)
        {
            if (count == 0)
                throw new InvalidOperationException();
            if (index >= count)
                throw new InvalidOperationException();

            int actualIndex = 0;
            T foundItem = default(T);
            for (int i = front; i <= rear; i++)
            {
                if (actualIndex == index)
                {
                    foundItem = array[i];
                    break;
                }
                actualIndex++;
            }
            return foundItem;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = front; i <= rear; i++)
                yield return array[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
