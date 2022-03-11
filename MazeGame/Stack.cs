using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public class Stack<T>
    {
        private List<T> list = new List<T>();

        public T pop()
        {
            T t = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return t;
        }

        public void push(T t)
        {
            if (!list.Contains(t))
            {
                list.Add(t);
            }
        }

        public int getSize()
        {
            return list.Count;
        }
    }
}
