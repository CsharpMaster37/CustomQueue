using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class CustomQueue<T>
    {
        private T[] _items;
        private int _head = 0, _tail = 0, Capacity = 4;
        public int Count { get; private set; } = 0;
        public CustomQueue()
        {
            _items = new T[Capacity];
        }
        public void Enqueue(T value)
        {
            if (Count == Capacity)
            {
                Capacity *= 2;
                ChangeCapacity();
            }
            _items[(_tail++) % Capacity] = value;
            Count++;
        }
        public T Dequeue()
        {
            CheckCount();
            Count--;
            return _items[(_head++) % Capacity];
        }
        public T Peek()
        {
            CheckCount();
            return _items[_head];
        }

        public bool Contains(T value)
        {
            int idx = _head;
            for (int i = 0; i < Count; i++)
            {
                if (_items[(idx++)%Capacity].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        private void CheckCount()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
        private void ChangeCapacity()
        {
            T[] _tempItems = new T[Capacity];
            if (_head < _tail)
            {
                Array.Copy(_items, _head, _tempItems, 0, Count);
            }
            else
            {
                Array.Copy(_items, _head, _tempItems, 0, Capacity/2 - _head);
                Array.Copy(_items, 0, _tempItems, Capacity / 2 - _head, _tail);
            }
            _items = _tempItems;
            _head = 0;
            _tail = Count;
        }
    }
}
