using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IEEE754
{
    public static class DoubleExtensions
    {
        public static string GetBinaryRepresentation(this double number)
        {
            DoubleLongUnion union = new DoubleLongUnion {Double = number};
            long @long = union.Long;
            return Convert.ToString(@long, 2).PadLeft(64, '0');
        }

        public static unsafe string GetBinaryRepresentationUnsafe(this double number)
        {
            double* pNumber = &number;
            long* pLong = (long*) pNumber;
            long @long = *pLong;
            return Convert.ToString(@long, 2).PadLeft(64, '0');
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleLongUnion
        {
            [FieldOffset(0)]
            public double Double;

            [FieldOffset(0)]
            public long Long;
        }
    }
}
