using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList.Model
{
    public class DuplexLinkedList<T> : IEnumerable<T>
    {
        private DuplexItem<T> Head { get; set; }
        private DuplexItem<T> Tail { get; set; }
        public int Count { get; private set; }

        public DuplexLinkedList() { }

        public DuplexLinkedList(T data)
        {
            Set(data);
        }

        private void Set(T data)
        {
            var item = new DuplexItem<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
            return;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
            return;
        }

        public void Add(T data)
        {
            if (Count != 0)
            {
                var item = new DuplexItem<T>(data);
                Tail.Next = item;
                item.Previous = Tail;
                Tail = item;
                Count++;
                return;
            }
            else
            {
                Set(data);
                return;
            }
        }

        public void Delete(T data)
        {
            if(Head != null)
            {
                var current = Head;
                while(current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        if (current != Tail)
                        {
                            current.Previous.Next = current.Next;
                            current.Next.Previous = current.Previous;
                            Count--;
                            return;
                        }
                        else
                        {
                            current.Previous.Next = null;
                            Tail = current.Previous;
                            Count--;
                            return;
                        }
                    }
                    current = current.Next;
                }
            }
            else
            {
                throw new ArgumentNullException("Where's my money cowboy?");
            }
        }

        public DuplexLinkedList<T> Reverse()
        {
            var result = new DuplexLinkedList<T>();

            var current = Tail;

            while(current != null)
            {
                result.Add(current.Data);
                current = current.Previous;
            }
            return result;
        }


        public override string ToString()
        {
            return $"DuplexLinkedList has {Count} elements";
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
