using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckyNumbers
{
	public class LuckyNumberCalculator
	{
		private SumMemoTable _sumMemoTable;
		private PrimeTable _primeTable;
	
		public LuckyNumberCalculator(Int64 maxDigits, Int64 digitRange)
		{
			GenerateTables(maxDigits, digitRange);
		}

		public Int64 Calculate(Int64 lowerBound, Int64 upperBound)
		{
			var result = Calculate(upperBound) - Calculate(lowerBound);
			var lowerBoundDigits = GetDigits(lowerBound);

			if (_primeTable.Contains(lowerBoundDigits.Sum()) &&
				_primeTable.Contains(lowerBoundDigits.Sum(x => x * x)))
			{
				return result + 1;
			}

			return result;
		}
	
		public Int64 Calculate(Int64 number)
		{
			var result = (Int64)0;
			var constraint = (Int64)0;
		
			var digits = GetDigits(number);
			var currentDigitIndex = digits.Count() - 1;
		
			foreach (var digit in digits)
			{
				for (var i = 0; i < digit; i++)
				{
					for (var j = 0; j < _primeTable.Count(); j++)
					{
						for (var k = 0; k < _primeTable.Count(); k++) 
						{
							result += _sumMemoTable[currentDigitIndex, 
													i,
													(_primeTable[j] - constraint), 
													(_primeTable[k] - (constraint * constraint))];
						}
					}
				}
			
				constraint += digit;
				currentDigitIndex--;
			}
	
			if (_primeTable.Contains(digits.Sum()) &&
				_primeTable.Contains(digits.Sum(x => x * x)))
				return result + 1;
		
			return result;
		}
	
		private List<Int64> GetDigits(Int64 number)
		{
			var digits = new List<Int64>();
	
			while (number > 0)
			{
				digits.Add(number % 10);
				number = number / 10;
			}
		
			digits.Reverse();

			return digits;
		}
	
		private void GenerateTables(Int64 maxDigits, Int64 digitRange)
		{
			_sumMemoTable = new SumMemoTableGenerator().Generate(maxDigits, digitRange);
			_primeTable = new PrimeTableGenerator().Generate(_sumMemoTable.MaxSquareSum);
		}
	}
}