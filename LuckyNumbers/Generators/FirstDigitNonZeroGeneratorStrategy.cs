using System;

namespace LuckyNumbers
{
	public class FirstDigitNonZeroGeneratorStrategy : IGeneratorStrategy
	{
		private SumMemoTable _sumMemoTable;	
		private Int64 _numDigits;
		private Int64 _firstDigit;
	
		public FirstDigitNonZeroGeneratorStrategy(SumMemoTable sumMemoTable, Int64 numDigits, Int64 firstDigit)
		{
			_sumMemoTable = sumMemoTable;
			_numDigits = numDigits;
			_firstDigit = firstDigit;
		}
	
		public void Run()
		{
			for (var j = 0; j <= _sumMemoTable.MaxLinearSum - _firstDigit; j++)
			{
				for (var k = 0; k <= _sumMemoTable.MaxSquareSum - (_firstDigit * _firstDigit); k++)
				{
					_sumMemoTable[_numDigits, _firstDigit, j + _firstDigit, k + (_firstDigit * _firstDigit)] 
						+= _sumMemoTable[_numDigits, 0, j, k]; 
				}
			}
		}
	}
}