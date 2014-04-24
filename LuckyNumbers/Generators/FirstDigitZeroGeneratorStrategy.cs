using System;

namespace LuckyNumbers
{
	public class FirstDigitZeroGeneratorStrategy : IGeneratorStrategy
	{
		private SumMemoTable _sumMemoTable;
		private Int64 _numDigits;
	
		public FirstDigitZeroGeneratorStrategy(SumMemoTable sumMemoTable, Int64 numDigits)
		{
			_sumMemoTable = sumMemoTable;
			_numDigits = numDigits;
		}
	
		public void Run()
		{
			for (var i = 0; i <= _sumMemoTable.DigitRange; i++)
			{
				for (var j = 0; j <= _sumMemoTable.MaxLinearSum; j++)
				{
					for (var k = 0; k <= _sumMemoTable.MaxSquareSum; k++)
					{
						_sumMemoTable[_numDigits, 0, j, k] += _sumMemoTable[_numDigits - 1, i, j, k];
					}
				}
			}
		}
	}
}