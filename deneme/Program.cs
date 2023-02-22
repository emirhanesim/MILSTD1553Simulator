using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MILSTD1553ClassLibrary;

namespace deneme
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandWord = 123;
            int[] dataWord = { 1, 1, 0, 1, 0, 1 };
            int[] message;
            float messageDuration;
            Message msg = new Message(commandWord, dataWord);
            message = msg.returnMessage();
            messageDuration = msg.getMessageDuration();
            while (true) ;
        }
    }
}
