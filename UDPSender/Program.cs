using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPSender
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("UDP Sender\nType Your Message: ");
            string message = Console.ReadLine();
            IPAddress multiaddress = IPAddress.Parse("239.0.0.222");
            UdpClient client = new UdpClient();
            client.JoinMulticastGroup(multiaddress);
            client.Ttl = 5;
            IPEndPoint ep = new IPEndPoint(multiaddress, 49552);
            Byte[] buff = Encoding.Unicode.GetBytes(message);
            client.Send(buff, buff.Length, ep);
        }
    }
}
