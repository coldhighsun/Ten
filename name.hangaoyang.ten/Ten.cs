using System;
using System.Collections.Generic;
using System.Globalization;

namespace name.hangaoyang.ten
{
	internal class Ten
	{
		private readonly List<NodeType> Results = new List<NodeType>();

		public void Calc()
		{
			NodeType NewNode = new ten.NodeType(10, 1, 0, 10, 0, 10, null);

			Results.Add(NewNode);
			Results.Add(NewNode);

			for (int i = 2; i < 5; i++)
			{
				Calc(i);
			}
		}

		public void Print()
		{
			for (int Value = 1; Value <= 10; Value++)
			{
				Console.WriteLine($"Result of Value {Value}:");
				Console.WriteLine("------------------------------------");
				for (int i = 0; i < Results.Count; i++)
				{
					if (Results[i].NumberCount == 4 && Results[i].Value == Value)
					{
						Print(i);
						Console.WriteLine();
					}
				}

				Console.WriteLine();
			}
		}

		private static double? Factorial(double value)
		{
			if (value > 30)
			{
				return null;
			}

			int Result;
			if (int.TryParse(value.ToString(CultureInfo.InvariantCulture), out Result))
			{
				Result = 1;
				for (int i = 2; i <= value; i++)
				{
					Result = Result * i;
				}
			}

			return Result;
		}

		private void Calc(int numberCount)
		{
			for (int i = 0; i < Results.Count - 1; i++)
			{
				for (int j = i + 1; j < Results.Count; j++)
				{
					if (Results[i].NumberCount + Results[j].NumberCount == numberCount)
					{
						CheckAndAdd(new NodeType(Results[i].Value + Results[j].Value, numberCount, i, Results[i].Value, j, Results[j].Value, "+"));

						CheckAndAdd(new NodeType(Results[i].Value - Results[j].Value, numberCount, i, Results[i].Value, j, Results[j].Value, "-"));
						CheckAndAdd(new NodeType(Results[j].Value - Results[i].Value, numberCount, j, Results[j].Value, i, Results[i].Value, "-"));

						CheckAndAdd(new NodeType(Results[i].Value * Results[j].Value, numberCount, i, Results[i].Value, j, Results[j].Value, "*"));

						CheckAndAdd(new NodeType(Results[i].Value / Results[j].Value, numberCount, i, Results[i].Value, j, Results[j].Value, "/"));
						CheckAndAdd(new NodeType(Results[j].Value / Results[i].Value, numberCount, j, Results[j].Value, i, Results[i].Value, "/"));

						CheckAndAdd(new NodeType(Math.Pow(Results[i].Value, Results[j].Value), numberCount, i, Results[i].Value, j, Results[j].Value, "^"));
						CheckAndAdd(new NodeType(Math.Pow(Results[j].Value, Results[i].Value), numberCount, j, Results[j].Value, i, Results[i].Value, "^"));
					}
				}
			}

			for (int i = 0; i < Results.Count; i++)
			{
				double Temp = Math.Sqrt(Results[i].Value);
				int Result;
				if (int.TryParse(Temp.ToString(CultureInfo.InvariantCulture), out Result))
				{
					CheckAndAdd(new NodeType(Temp, Results[i].NumberCount, i, Results[i].Value, i, Results[i].Value, "sqrt"));
				}

				double? F = Factorial(Results[i].Value);
				if (F.HasValue)
				{
					CheckAndAdd(new NodeType(F.Value, Results[i].NumberCount, i, Results[i].Value, i, Results[i].Value, "!"));
				}
			}
		}

		private void CheckAndAdd(NodeType newNode)
		{
			if (!double.IsInfinity(newNode.Value) && !Results.Contains(newNode))
			{
				Results.Add(newNode);
			}
		}

		private void Print(int id)
		{
			if (id > 1)
			{
				switch (Results[id].Method)
				{
					case "sqrt":
						Console.Write("√(");
						Print(Results[id].LeftId);
						Console.Write(")");
						break;

					case "!":
						if (Results[id].NumberCount > 1)
						{
							Console.Write("(");
						}
						Print(Results[id].LeftId);
						if (Results[id].NumberCount > 1)
						{
							Console.Write(")");
						}
						Console.Write("!");
						break;

					default:
						Console.Write("(");
						Print(Results[id].LeftId);
						Console.Write($" {Results[id].Method} ");
						Print(Results[id].RightId);
						Console.Write(")");
						break;
				}
			}
			else
			{
				Console.Write(Results[id].Value);
			}
		}
	}
}