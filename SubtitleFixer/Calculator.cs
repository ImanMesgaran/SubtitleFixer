using System;
using System.Collections.Generic;
using System.Text;

namespace SubtitleFixer
{
	public class Calculator
	{
		public int FirstNumber { get; set; }
		public int SecondNumber { get; set; }

		public int Add()
		{
			return FirstNumber + SecondNumber;
		}

		public int Add(int a, int b)
		{
			return a + b;
		}

		public int Subtract(int a, int b)
		{
			return a - b;
		}
	}
}
