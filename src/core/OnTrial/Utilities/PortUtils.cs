using System.Net;
using System.Net.Sockets;

namespace OnTrial.Utilities
{
    public static class PortUtils
    {
        public static int OpenPort
        {
            get
            {
                int listeningPort = 0;
                Socket portSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    IPEndPoint socketEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    portSocket.Bind(socketEndPoint);
                    socketEndPoint = (IPEndPoint)portSocket.LocalEndPoint;
                    listeningPort = socketEndPoint.Port;
                }
                finally
                {
                    portSocket.Close();
                }
                return listeningPort;
            }
        }
    }
}
