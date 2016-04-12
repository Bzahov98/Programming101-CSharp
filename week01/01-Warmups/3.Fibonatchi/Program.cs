using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_One
{
	class Program
	{
		static void Main(string[] args)
		{
			var c = 0;
			int a = 1;
			int b = 1;
			int n = int.Parse(Console.ReadLine());
			//string str;
			Console.Write(a);// for concatenating	list

			Console.Write(b);// for concatenating	list
			for (var i = 0; i < n - 2; i++)
			{
				c = a + b;
				a = b;
				b = c;
				Console.Write(c); // for concatenating	list
				//Console.WriteLine( b);
			}
			//Console.Write(c); // for only n number
			Console.ReadLine();
		}
	}
}
