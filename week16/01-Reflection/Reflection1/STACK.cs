using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection1
{

	public class Stack<T>
		where T : IComparable<T>
	{

		int stackSize;
		int top;
		T[] stack;

		public Stack()
		{
			stackSize = 10;
			stack = new T[stackSize];
			top = -1;
		}

		public T Peek()
		{
			return stack[top];
		}

		public T Pop()
		{
			T result = Peek();
			top--;
			return result;
		}

		public void Push(T obj)
		{
			top++;
			if (top == stackSize)
			{
				stackSize += 5;
				T[] tmp = new T[stackSize];
				for (int i = 0; i < stack.Length; i++)
				{
					tmp[i] = stack[i];
				}
				tmp[stackSize] = obj;
				stack = tmp;
			}
			else
				stack[top] = obj;
		}

		public void Clear()
		{
			stack = new T[stackSize];
			top = 0;
		}

		public bool Contains(T obj)
		{
			foreach (var item in stack)
			{
				if (item.CompareTo(obj) == 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
