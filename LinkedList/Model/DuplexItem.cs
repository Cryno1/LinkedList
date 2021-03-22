using System;
namespace LinkedList.Model
{
    public class DuplexItem<T>
    {
        public T Data { get; private set; }

        public DuplexItem<T> Previous { get; set; }
        public DuplexItem<T> Next { get; set; }

        public DuplexItem() { }

        public DuplexItem(T data)
        {
            Data = data;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
