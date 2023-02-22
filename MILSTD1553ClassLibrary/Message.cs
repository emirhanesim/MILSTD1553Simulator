using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILSTD1553ClassLibrary
{
    public class Message
    {
        private int CommandWord { get; set; }
        private int DataWordArrayLength { get; set; }
        private int[] DataWordArray { get; set; }
        private int messageDuration;

        //Constructor for BC-RT (RT receives) message
        public Message(int commandWord, int[] dataWordArray)
        {
            this.CommandWord = commandWord;
            this.DataWordArray = dataWordArray;
            this.DataWordArrayLength = dataWordArray.Length;
        }

        //Constructor for RT-BC (RT transmits) message
        public Message(int commandWord) 
        {
            this.CommandWord = commandWord;
            this.DataWordArray = null;
            this.DataWordArrayLength = 0;
        }

        //Method: getMessageDuration
            //returns in millisecond
            //word duration: 16 ms (16 bit x 1 ms)
        public int getMessageDuration()
        {
            messageDuration = 1 * (1 + DataWordArrayLength);
            return messageDuration;
        }

        
        public int[] returnMessage()
        {
            int[] messageArray = new int[1 + DataWordArrayLength];
            if (DataWordArray != null)
            {
                messageArray[0] = CommandWord;
                DataWordArray.CopyTo(messageArray, 1);
            }
            else
            {
                messageArray[0] = CommandWord;
            }
            return messageArray;
        }
    }
}
