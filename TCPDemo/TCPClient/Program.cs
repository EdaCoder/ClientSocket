using BeetleX.Clients;
using BeetleX;

namespace TCPClient
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var client = SocketFactory.CreateClient<AsyncTcpClient>("127.0.0.1", 909);
            var x = client.IsConnected;
            client.DataReceive = (o, e) =>
            {
                var pipestream = e.Stream.ToPipeStream();
                var line = pipestream.ReadLine();
                Console.WriteLine($"{DateTime.Now} {line}");
            };
            while (true)
            {
                Console.Write("Enter Name:");
                var line = Console.ReadLine();
                client.Stream.ToPipeStream().WriteLine(line);
                client.Stream.Flush();

            }

        }
    }
}
