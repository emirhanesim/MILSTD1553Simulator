using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MILSTD1553ClassLibrary
{
    public class TCPServer
    {
        private TcpClient client;
        private TcpListener listener;
        private int port = 5000;
        public int newRead = 0;
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
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public int[] receive()
        {
            byte[] receivedData = new byte[256];
            while (stream.DataAvailable == false) ;
            receivedDataLength = stream.Read(receivedData, 0, 256); //one message is maximum of 66 bytes = 33 words
            int[] returnData = new int[receivedDataLength / 2];
            byte[] receivedDataByte = new byte[receivedDataLength];
            Array.Copy(receivedData, 0, receivedDataByte, 0, receivedDataLength);
            returnData = byteToInt(receivedDataByte);
            return returnData;
        }

        public void send(int[] message)
        {
            try
            {
                if(client.Connected)
                {
                    byte[] messageByteArr = intToByte(message);
                    stream.Write(messageByteArr, 0, messageByteArr.Length);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private int[] byteToInt(byte[] valueArr)
        {
            
            int valueArrLength = valueArr.Length;
            
            if ((valueArrLength % 2) == 0)
            {
                int[] dataReturn = new int[valueArrLength / 2];
                int k = 0;
                for (int i = 0; i < valueArrLength-1; i+=2)
                {
                    dataReturn[k] = valueArr[i+1] + (valueArr[i] << 8);
                    k++;
                }
                return dataReturn;
            }

            else
            {
                throw new ArgumentException("provided byte array length is not multiple of 2");
            }

        }

        private byte[] intToByte(int[] valueArr)
        {
            int valueArrLength = valueArr.Length;
            int returnArrLength = valueArrLength * 2;
            byte[] dataReturn = new byte[returnArrLength];
            for(int i = 0; i < valueArrLength; i++)
            {
                dataReturn[2*i] = (byte)(valueArr[i] >> 8);
                dataReturn[2*i + 1] = (byte)valueArr[i];
            }
            return dataReturn;
        }
    }
}

