using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckyNumbers
{
	public class PrimeTable
	{
		private readonly List<Int64> _primeTable;

		public PrimeTable(List<Int64> primeTable)
		{
			_primeTable = primeTable;
		}
	
		public Int64 Count()
		{
			return _primeTable.Count();
		}

		public Boolean Contains(Int64 item)
		{
			return _primeTable.Contains(item);
		}

		public Int64 this[Int32 index]
		{
			get 
			{
				if (index >= 0 && index < _primeTable.Count())
					return _primeTable[index];
				else
					return 0;
			}
		}
	}
}