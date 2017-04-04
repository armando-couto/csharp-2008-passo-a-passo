
namespace Operators
{
	struct Minute
	{
		public Minute(int initialValue)
		{
			this.value = System.Math.Abs(initialValue) % 60;
		}

		public int Value
		{
			get { return this.value; }
		}

        public static bool operator ==(Minute lhs, int rhs)
        {
            return lhs.value == rhs;
        }

        public static bool operator !=(Minute lhs, int rhs)
        {
            return lhs.value != rhs;
        }

		public override bool Equals(object other)
		{
			return (other is Minute) && Equals((Minute)other);
		}

		public bool Equals(Minute other)
		{
			return this.value == other.value;
		}

		public override int GetHashCode()
		{
			return this.value;
		}

		public static Minute operator++(Minute arg)
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
