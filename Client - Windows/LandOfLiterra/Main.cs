using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LandOfLiterra {

    public static class globals {
        public static bool loggedIn = false;
        public static string serverAddr;
        public static int serverPort;
        public static string[][] servers;
    }

    public class Client {
        public static void Primary() {
            byte[] data = new byte[2048];
            string input, stringData;
            IPEndPoint ipep = new IPEndPoint(
                            IPAddress.Parse(globals.serverAddr), globals.serverPort);

            Socket server = new Socket(AddressFamily.InterNetwork,
                           SocketType.Stream, ProtocolType.Tcp);

            try {
                server.Connect(ipep);
            }
            catch (SocketException e) {
                Console.WriteLine("Unable to connect to server.");
                Console.WriteLine(e.ToString());
                return;
            }


            int recv = server.Receive(data);
            stringData = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine(stringData);

            while (true) {
                input = Console.ReadLine();
                if (input == "exit")
                    break;
                server.Send(Encoding.ASCII.GetBytes(input));
                data = new byte[2048];
                recv = server.Receive(data);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
            Console.WriteLine("Disconnecting from server...");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }

}