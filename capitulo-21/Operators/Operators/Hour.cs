
namespace Operators
{
	struct Hour
	{
		public Hour(int initialValue)
		{
			this.value = System.Math.Abs(initialValue) % 24;
		}

		public int Value
		{
			get { return this.value; }
		}

		public static bool operator==(Hour lhs, int rhs)
		{
			return lhs.value == rhs;
		}

		public static bool operator!=(Hour lhs, int rhs)
		{
			return lhs.value != rhs;
		}

		public static bool operator==(int lhs, Hour rhs)
		{
			return lhs == rhs.value;
		}

		public static bool operator!=(int lhs, Hour rhs)
		{
			return lhs != rhs.value;
		}

		public override bool Equals(object other)
		{
			return (other is Hour) && Equals((Hour)other);
		}

		public bool Equals(Hour other)
		{
			return this.value == other.value;
		}

		public override int GetHashCode()
		{
			return this.value;
		}

		public static Hour operator++(Hour arg)
		{
			arg.value++;
			if (arg.value == 24)
			{
				arg.value = 0;
			}
			return arg;
		}

		private int value;
	}
}