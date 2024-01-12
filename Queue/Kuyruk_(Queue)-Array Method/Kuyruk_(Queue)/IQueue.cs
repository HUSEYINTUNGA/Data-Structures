using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuyruk__Queue_
{
    public interface IQueue<T>:IEnumerable<T>
    {
        int Size();
        void enQueue(T item);
        T deQueue();
        bool contains(T item);
        T access(int index);
    }
}
