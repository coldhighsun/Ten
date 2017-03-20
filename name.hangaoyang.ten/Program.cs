using System;

namespace name.hangaoyang.ten
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			Ten MyTen = new Ten();
			MyTen.Calc();
			MyTen.Print();

			Console.ReadKey();
		}
	}
}