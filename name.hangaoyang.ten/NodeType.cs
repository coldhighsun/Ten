using System;

namespace name.hangaoyang.ten
{
	internal class NodeType : IEquatable<NodeType>
	{
		public NodeType(double value, int numberCount, int leftId, double leftValue, int rightId, double rightValue, string method)
		{
			LeftId = leftId;
			LeftValue = leftValue;
			RightId = rightId;
			RightValue = rightValue;
			NumberCount = numberCount;
			Value = value;
			Method = method;
		}

		public int LeftId
		{
			get;
		}

		public double LeftValue
		{
			get;
		}

		public string Method
		{
			get;
		}

		public int NumberCount
		{
			get;
		}

		public int RightId
		{
			get;
		}

		public double RightValue
		{
			get;
		}

		public double Value
		{
			get;
		}

		public bool Equals(NodeType other)
		{
			if (other != null)
			{
				return
					Math.Abs(LeftValue - other.LeftValue) < 0.00001 &&
					NumberCount == other.NumberCount &&
					Math.Abs(RightValue - other.RightValue) < 0.00001 &&
					string.Equals(Method, other.Method, StringComparison.OrdinalIgnoreCase) &&
					Math.Abs(Value - other.Value) < 0.00001;
			}
			else
			{
				return false;
			}
		}
	}
}