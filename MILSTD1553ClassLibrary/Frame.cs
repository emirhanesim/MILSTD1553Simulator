using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILSTD1553ClassLibrary
{
    public class Frame //add messages, remove messages, run, 
    {
        
        private int FrameTime { get; } //in millisecond
        private List<Message> messages;

        private int messageDuration;
        private int totalMessageDuration = 0;

        public Frame(int frameTime) //takes message list
        {
            this.FrameTime = frameTime;
        }
        public bool addMessage(Message message)
        {
            if((totalMessageDuration + message.MessageDuration) >= FrameTime)
            {
                return false;
            }
            else
            {
                messages.Add(message);
                totalMessageDuration += message.MessageDuration;
                return true;
            }
        }

        public void run(TCPServer server)
        {
            while (true)
            {
                 
            }
        }

        // send and receive logics are going to be added later.
    }
}
