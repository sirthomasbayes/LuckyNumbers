using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			var calculator = new LuckyNumberCalculator(18, 9);
			Console.WriteLine(calculator.Calculate(1, 20));
			Console.WriteLine(calculator.Calculate(120, 130));
			Console.WriteLine(calculator.Calculate(1, 1000000000));
			Console.WriteLine(calculator.Calculate(1, 100000000000000000)); 

			Console.ReadLine();
		}
	}
}
