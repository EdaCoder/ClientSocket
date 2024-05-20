using BeetleX;
using BeetleX.EventArgs;

namespace TCPServer
{
    public class Program:ServerHandlerBase
    {
        private static IServer server;
        public static void Main(string[] args)
        {
            server = SocketFactory.CreateTcpServer<Program>();
            server.Options.DefaultListen.Port = 9000;
            server.Open();
            Console.Read();
        }
        public override void SessionReceive(IServer server, SessionReceiveEventArgs e)
        {
            var pipeStream = e.Stream.ToPipeStream();
            if (pipeStream.TryReadLine(out string name))
            {
                Console.WriteLine(name);
                pipeStream.WriteLine("hello " + name);
                e.Session.Stream.Flush();
            }
            base.SessionReceive(server, e);
        }
    }
}
