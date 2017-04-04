
namespace Operators
{
	struct Second
	{
		public Second(int initialValue)
		{
			this.value = System.Math.Abs(initialValue) % 60;
		}

		public int Value
		{
			get { return this.value; }
		}

        public static implicit operator Second(int arg)
        {
            return new Second(arg);
        }

		// don't delete the following operator
		public static bool operator==(Second lhs, Second rhs)
		{
			return lhs.value == rhs.value;
		}

        //public static bool operator==(Second lhs, int rhs)
        //{
        //    return lhs.value == rhs;
        //}

        //public static bool operator==(int lhs, Second rhs)
        //{
        //    return lhs == rhs.value;
        //}
		
		// don't delete the following operator
		public static bool operator!=(Second lhs, Second rhs)
		{
			return lhs.value != rhs.value;
		}

        //public static bool operator!=(Second lhs, int rhs)
        //{
        //    return lhs.value != rhs;
        //}

        //public static bool operator!=(int lhs, Second rhs)
        //{
        //    return lhs != rhs.value;
        //}

		public override bool Equals(object other)
		{
			return (other is Second) && Equals((Second)other);
		}

		public bool Equals(Second other)
		{
			return this.value == other.value;
		}

		public override int GetHashCode()
		{
			return this.value;
		}

		public static Second operator++(Second arg)
		{
			arg.value++;
			if (arg.value == 60)
			{
				arg.value = 0;
			}
			return arg;
		}

		private int value;
	}
}
