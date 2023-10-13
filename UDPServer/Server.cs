using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPServer
{
    static void Main()
    {
        string IP = "192.168.0.253";
        int port = 24411;

        IPAddress addr = IPAddress.Parse(IP);
        IPEndPoint localEP = new IPEndPoint(addr, port);
        UdpClient udpClient = new UdpClient(localEP);

        Console.WriteLine("Server started at {0}:{1}", addr, port);

        while (true)
        {
            IPEndPoint remote = null;
            byte[] recv = udpClient.Receive(ref remote);
            string msg = Encoding.UTF8.GetString(recv);

            Console.WriteLine(msg);

            if (msg.Equals("exit"))
            {
                break;
            }
            else { }
        }

        udpClient.Close();
    }
}