using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILSTD1553ClassLibrary
{
    public class Buffer32
    {
        public static int[] buffer = new int[32];

        public static void writeToBuffer(int[] data)
        {
            int dataLength = data.Length;
            for(int i = 0; i < dataLength; i++)
            {
                buffer[i] = data[i];
            }
        }
    }
}
