using System;
using System.Collections.Generic;

namespace LuckyNumbers
{
	public class PrimeTableGenerator
	{	
		public PrimeTable Generate(Int64 limit)
		{
			var primeList = new List<Int64>() { 2 };

			for (var i = 3; i <= limit; i++)
			{
				var isPrime = true;
			
				foreach (var prime in primeList)
				{
					if (i % prime == 0)
					{
						isPrime = false;
						break;
					}
				}
			
				if (isPrime)
				{
					primeList.Add(i);
				}
			}
		
			return new PrimeTable(primeList);
		}
	}
}