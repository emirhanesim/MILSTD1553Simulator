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
        public void addMessage(Message message)
        {
            if((totalMessageDuration + message.getMessageDuration()) >= FrameTime)
            {
                throw new Exception("the messages exceed the frame time. ");
            }
            else
            {
                messages.Add(message);
                totalMessageDuration += message.getMessageDuration();
            }
        }

        // send and receive logics are going to be added later.
    }
}
