using System;
using System.Collections;

namespace LinkedList.Model
{
    //Класс обьекта
    class Item<T>
    {
        private T data = default(T);

        public T Data
        {
            get
            { return data; }
            set
            {
                data = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Item<T> Next { get; set; }

        public Item(T data)
        {
            Data = data;
        }

    }
}
