using System;

namespace LuckyNumbers
{
	public class SumMemoTableGenerator
	{
		private IGeneratorStrategy _strategy; 
	
		public SumMemoTable Generate(Int64 maxDigits, Int64 digitRange)
		{	
			var maxLinearSum = maxDigits * digitRange;
			var maxSquareSum = maxDigits * digitRange * digitRange;
		
			var sumMemoTable = new SumMemoTable(maxDigits, digitRange);
		
			_strategy = new OneDigitGeneratorStrategy(sumMemoTable);
			_strategy.Run();
		
			for (var i = 1; i < maxDigits; i++)
			{
				for (var j = 0; j <= digitRange; j++)
				{
					if (j == 0)
					{
						_strategy = new FirstDigitZeroGeneratorStrategy(sumMemoTable, i);
					}
					else
					{
						_strategy = new FirstDigitNonZeroGeneratorStrategy(sumMemoTable, i, j);
					}
				
					_strategy.Run();
				}
			}

			return sumMemoTable;
		}
	}
}