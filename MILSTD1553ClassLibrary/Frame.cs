using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILSTD1553ClassLibrary
{
    public class Frame
    {
        
        private int FrameTime { get; } //in millisecond
        private List<Message> messages;

        private int messageDuration;
        private int totalMessageDuration = 0;

        public Frame(int frameTime)
        {
            this.FrameTime = frameTime;
        }
        public bool addMessage(Message message)
        {
            if((totalMessageDuration + message.getMessageDuration()) >= FrameTime)
            {
                return false;
            }
            else
            {
                messages.Add(message);
                totalMessageDuration += message.getMessageDuration();
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
