using System;

namespace LuckyNumbers
{
	public class OneDigitGeneratorStrategy : IGeneratorStrategy
	{
		private SumMemoTable _sumMemoTable;

		public OneDigitGeneratorStrategy(SumMemoTable sumMemoTable)
		{
			_sumMemoTable = sumMemoTable;
		}
	
		public void Run()
		{
			for (var i = 0; i <= _sumMemoTable.DigitRange; i++)
			{
				_sumMemoTable[0, i, i, i * i] = 1;
			}
		}
	}
}