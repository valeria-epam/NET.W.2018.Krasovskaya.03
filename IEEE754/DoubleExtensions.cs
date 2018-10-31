using System.Runtime.InteropServices;

namespace IEEE754
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Gets the binary representation of <see cref="double"/> <paramref name="number"/>.
        /// </summary>
        public static string GetBinaryRepresentation(this double number)
        {
            DoubleLongUnion union = new DoubleLongUnion { Double = number };
            ulong bits = union.Ulong;
            return ConvertToString(bits);
        }

        /// <summary>
        /// Gets the binary representation of <see cref="double"/> <paramref name="number"/> using unsafe code.
        /// </summary>
        public static unsafe string GetBinaryRepresentationUnsafe(this double number)
        {
            double* numberPointer = &number;
            ulong* bitsPointer = (ulong*)numberPointer;
            ulong bits = *bitsPointer;
            return ConvertToString(bits);
        }

        private static string ConvertToString(ulong bits)
        {
            char[] chars = new char[64];

            int i = 63;
            while (bits != 0)
            {
                chars[i] = bits % 2 == 0 ? '0' : '1';
                bits /= 2;
                i -= 1;
            }

            while (i >= 0)
            {
                chars[i] = '0';
                i -= 1;
            }

            return new string(chars);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleLongUnion
        {
            [FieldOffset(0)]
            public double Double;

            [FieldOffset(0)]
            public ulong Ulong;
        }
    }
}
