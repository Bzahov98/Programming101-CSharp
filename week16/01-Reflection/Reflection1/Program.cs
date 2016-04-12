using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtentionMethod; 
namespace Reflection1
{
	class Program
	{
		static void Main(string[] args)
		{
			var testclass = new Test1();
			testclass.P = 5;
			testclass.A = 9;
			A.Method(testclass);
			Console.WriteLine(testclass.P);
			Console.WriteLine(testclass.A);
			Console.Read();
		}
	}

	[Incrementable]
	class Test1
	{
		public int P { get; set; }
		public int A { get; set; }
	}
}