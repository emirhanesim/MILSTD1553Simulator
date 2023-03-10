using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MILSTD1553ClassLibrary
{
    class TCPServer
    {
        private TcpClient client;
        private TcpListener listener;
        private int port = 5000;
        public int newRead = 0;
        public byte[] receivedData = new byte[2];
        private int receivedDataLength;
        private NetworkStream stream;


        public TCPServer()
        {
            try
            {
                Thread t = new Thread(startListener);
                t.IsBackground = true;
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void startListener()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                client = listener.AcceptTcpClient();
                Thread t = new Thread(receive);
                t.IsBackground = true;
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void receive()
        {
            try
            {
                stream = client.GetStream();
                while (client.Connected)
                {
                    newRead = 0;
                    receivedDataLength = stream.Read(receivedData, 0, 2);
                    newRead = 1;
                    while (newRead == 1); //change newRead to zero after getting your data
                }
            }
            catch ( Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void send(int messageWord)
        {
            try
            {
                if(client.Connected)
                {
                    byte[] messageByteArr = intToByte(messageWord);
                    stream.Write(messageByteArr, 0, messageByteArr.Length);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private byte[] intToByte(int value)
        {
            byte[] data = new byte[2];
            data[0] = (byte)value;
            data[1] = (byte)(value >> 8);
            return data;
        }
    }
}

