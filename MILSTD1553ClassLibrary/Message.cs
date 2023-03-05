using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILSTD1553ClassLibrary
{
    public class Message
    {
        private CommandWord commandWord;
        private int[] messageBuffer; //holds the message as integer array
        private int messageDuration;
        
        
        

        public CommandWord CommandWord { get => commandWord; }
        public int[] MessageBuffer { get => messageBuffer; }
        public int MessageDuration { get => messageDuration; }

        public Message(CommandWord commandWord) //constructs message by getting data from buffer
        {
            
            this.commandWord = commandWord;
            messageBuffer = writeMessageBuffer(commandWord);
            messageDuration = getMessageDuration(messageBuffer);
        }


        //Method: getMessageDuration
            //returns in millisecond
            //word duration: 16 ms (16 bit x 1 ms)
        private int getMessageDuration(int[] messageBuffer)
        {
            int messageDurationReturn = 1 * (messageBuffer.Length);
            return messageDurationReturn;
        }
        private int[] writeMessageBuffer(CommandWord commandWord)
        {
            if (commandWord.TrBit == 0)
            {
                int[] dataReturn = new int[commandWord.WordCount + 1]; //BC-RT message. Holda cmd word and data words
                dataReturn[0] = commandWord.CommandWordInt;
                int[] buffer = Buffer32.buffer;
                Array.Copy(buffer, 0, dataReturn, 1, commandWord.WordCount); //copy the buffer with length of word count
                return dataReturn;
            }
            else 
            {
                int[] dataReturn = new int[1];
                dataReturn[0] = commandWord.CommandWordInt;
                return dataReturn;
            }
        }

        
    }
}
