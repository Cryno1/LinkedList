using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList.Model
{
    public class CircularList<T> : IEnumerable
    {
        private DuplexItem<T> Head { get; set; }
        public int Count { get; private set; }
        public CircularList() { }
        public CircularList(T data)
        {
            Set(data);
        }
        private void Set(T data)
        {
            Head = new DuplexItem<T>(data);
            Head.Next = Head;
            Head.Previous = Head;
            Count = 1;
            return;
        }
        public void Clear()
        {
            Head = null;
            Head.Next = null;
            Head.Previous = null;
            Count = 0;
            return;
        }

        public void Add(T data)
        {
            if(Count == 0)
            {
                Set(data);
                return;
            }
            var item = new DuplexItem<T>(data);
            item.Next = Head;
            item.Previous = Head.Previous;
            Head.Previous.Next = item;
            Head.Previous = item;
            Count++;
            return;
        }

        public void Delete(T data)
        {
            if (Head.Data.Equals(data))
            {
                Head.Next.Previous = Head.Previous;
                Head.Previous.Next = Head.Next;
                Head = Head.Next;
                Count--;
                return;
            }
            var current = Head;
            for(int i = Count; i > 0; i--)
            {
                if (current != null && current.Data.Equals(data))
                {
                    RemoveItem(current);
                    return;
                }
                current = current.Next;
            }

        }
        private void RemoveItem(DuplexItem<T> current)
        {
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            Count--;
            return;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            for (int i = 0; i < Count; i++)
            {
                yield return current;
                current = current.Next;
            }

        }
    }
}
