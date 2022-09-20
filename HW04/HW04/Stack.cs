using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW04
{
    public class Stack
    {
        //Создаем объект StackItem
        private StackItemList stackItem = new StackItemList();

        //Конструктор, принимающий неограниченное число параметров типа string
        public Stack(params string[] strList)
        {
            foreach (string str in strList)
            {
                Add(str);
            }
        }

        //Добавление одного элемента типа string в стек
        public void Add(string str)
        {
            stackItem.Add(str);
        }

        //Возвращает последний элемент стека, после этого удаляет его
        public string Pop()
        {
            if (stackItem == null)
            {
                throw new ArgumentOutOfRangeException("Стек пустой!");
            }
            else
            {
                string topEl = stackItem.GetElement(stackItem.GetCount() - 1);
                stackItem.RemoveLast();
                return topEl;
            }

        }

        //Возвращает размер стека
        public int Size()
        {
            if (stackItem.GetCount() == 0)
            {
                return 0;
            }
            else
            {
                return stackItem.GetCount();
            }

        }

        //Возвращает значение верхнего элемента из стека. Если стек пустой - возвращать null
        public string? Top()
        {
            if (stackItem.GetCount() == 0)
            {
                return null;
            }
            else
            {
                return stackItem.GetElement(stackItem.GetCount() - 1);
            }
        }

        /*
        Принимает на вход неограниченное количество параметров типа Stack и возвращает новый стек с элементами каждого стека в порядке параметров, 
        но сами элементы записаны в обратном порядке
         */
        public static Stack? Concat(params Stack[] stack)
        {
            if (stack.Length > 1)
            {
                stack[0] = invertStack(stack[0]);
                for (int i = 1; i < stack.Length; i++)
                {
                    stack[0].Merge(stack[i]);
                }
                return stack[0];
            }
            else if (stack.Length == 1)
            {
                return invertStack(stack[0]);
            }
            else
            {
                return null;
            }
        }

        //Функция, которая переворачивает первый объект типа Stack
        private static Stack invertStack(Stack stack)
        {
            Stack invertredStack = new Stack();
            for (int i = 0; i < stack.Size() + i; i++)
            {
                invertredStack.Add(stack.Pop());
            }
            return invertredStack;
        }
       
        //Класс для хранения состояния объектов класса Stack
        public class StackItemList
        {
            //Создаем объект типа LinkedList
            private LinkedList<string> _stack = new LinkedList<string>();
            //Создаем объект типа LinkedListNode для хранения ссылок на элементы стека
            private LinkedListNode<string>? currentNode = null;

            public void Add(string val, StackItemList? prev = null)
            {
                _stack.AddLast(val);
                //В объект LinkedListNode записываем ссылку на добавленный элемент
                currentNode = _stack.Last;
            }

            public int GetCount()
            {
                return _stack.Count;
            }

            public string GetElement(int index)
            {
                return _stack.ElementAt(index);
            }

            public void RemoveLast()
            {
                if (_stack.Count != 0)
                {
                    _stack.RemoveLast();                    
                }               
                
            }

            //Метод возвращает ссылку на предыдущий элемент в стеке, либо null
            public LinkedListNode<string>? getPrevious()
            {
                return currentNode.Previous;               
            }
        }
    }
}
