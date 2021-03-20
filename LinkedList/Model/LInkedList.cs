using System;
using System.Collections;

namespace LinkedList.Model
{
    //Класс списка
    
    class LinkedList<T> : IEnumerable
    {
        //Первый элемент списка
        public Item<T> Head { get; private set; }

        //Последний элемент списка
        public Item<T> Tail { get; private set; }

        //Кол-во элементов
        public int Count { get; private set; }

        public LinkedList()
        {//Очистка
            Clear();
        }
        public LinkedList(T data)
        {//Задаем первый элемент списка
            SetElements(data);
        }

        public void Add(T data)
        {
            //Добавляем элемент
            //Если хвост не равен нулю, то делаем новый элемент хвостом
            if (Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            //Иначе задаем первый элемент
            else
            {
                SetElements(data);
            }
        }
        
        //Добавить на место головы
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }

        //Добавить после выюранного элемента
        public void InsertAfter(T target, T data)
        {
            if(Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                //Можно добавить создание списка, но я этого делать конечно же не буду
            }
        }

        public void Delete(T data)
        {
            //Удаляем элемент
            //Если голова не равна нулю, то Сравниваем голову с вход-данными
            if(Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
                //Если данные не равны то пролистываем голову
                var current = Head.Next;
                var previous = Head;

                //И ищем текущий элемент и удаляем
                while(current.Next != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                SetElements(data);
            }
        }
        public void Clear() //Полная очистка
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        private void SetElements(T data)
        {
            //Первый элемент списка
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        public IEnumerator GetEnumerator()
        {
            //Нужно для работы списка как коллекции
            var current = Head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            //Ну а тут ТуСтринг переопределен
            return "Linked List" + Count + "elements";
        }
    }
}
