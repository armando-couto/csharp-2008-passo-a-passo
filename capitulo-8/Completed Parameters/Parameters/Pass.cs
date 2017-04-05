using System;

namespace Parameters
{
	class Pass
	{
        public static void Value(ref int param)
        {
            param = 43;
        }

        public static void Reference(WrappedInt param)
        {
            param.Number = 43;
        }
	}
}