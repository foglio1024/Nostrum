using System.Net.Sockets;

namespace Nostrum.Extensions
{
    public static class TcpClientExtensions
    {
        public static bool IsConnected(this TcpClient client)
        {
            if (!client.Client.Poll(0, SelectMode.SelectRead)) return false;
            return client.Client.Receive(new byte[1], SocketFlags.Peek) != 0;
        }
    }
}
