using System;

namespace LuckyNumbers
{
	public class SumMemoTable
	{
		private Int64[,,,] _sumMemoTable;
	
		private readonly Int64 _maxDigits;
		private readonly Int64 _digitRange;
		private readonly Int64 _maxLinearSum;
		private readonly Int64 _maxSquareSum;
	
		public SumMemoTable(Int64 maxDigits, Int64 digitRange)
		{
			_maxDigits = maxDigits;
			_digitRange = digitRange;
			_maxLinearSum = maxDigits * digitRange;
			_maxSquareSum = maxDigits * digitRange * digitRange;
		
			_sumMemoTable = new Int64[_maxDigits, _digitRange + 1, _maxLinearSum + 1, _maxSquareSum + 1];
		}
	
		public Int64 this[Int64 numDigits, Int64 firstDigit, Int64 linearSum, Int64 squareSum]
		{
			get 
			{
				if (numDigits >= 0 && numDigits < _maxDigits &&
					firstDigit >= 0 && firstDigit <= _digitRange &&
					linearSum >= 0 && linearSum <= _maxLinearSum &&
					squareSum >= 0 && squareSum <= _maxSquareSum)
				{
					return _sumMemoTable[numDigits, firstDigit, linearSum, squareSum];
				}
				else
				{
					return 0;
				}
			}
			set
			{
				if (linearSum >= 0 && linearSum <= _maxLinearSum && 
					squareSum >= 0 && squareSum <= _maxSquareSum)
				{
					_sumMemoTable[numDigits, firstDigit, linearSum, squareSum] = value;
				}
			}
		}
	
		public Int64 MaxDigits
		{
			get { return _maxDigits; }
		}
	
		public Int64 DigitRange
		{
			get { return _digitRange; }
		}
	
		public Int64 MaxLinearSum
		{
			get { return _maxLinearSum; }
		}
	
		public Int64 MaxSquareSum
		{
			get { return _maxSquareSum; }
		}
	}
}