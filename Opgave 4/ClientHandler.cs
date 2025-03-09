using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_4
{
    public class ClientHandler
    {

        public static void HandleClient(TcpClient client)
        {

            Console.WriteLine(client.Client.RemoteEndPoint);
            //gør det muligt at benytte TcpClient
            NetworkStream ns = client.GetStream();
            //vi modtager fra Client
            StreamReader reader = new StreamReader(ns);
            //Vi sender tilbage til Client
            StreamWriter writer = new StreamWriter(ns) { AutoFlush = true};


            while (true) 
            {
                string message = reader.ReadLine();
                Console.WriteLine("Client sent" + message);

                switch (message) 
                {
                    case "Random":
                        writer.WriteLine("Input numbers");

                        string[] numbers = reader.ReadLine().Split(' ');
                        int num1 = int.Parse(numbers[0]);
                        int num2 = int.Parse(numbers[1]);
                        Random rand = new Random();
                        string result = rand.Next(num1, num2 + 1).ToString();
                        writer.WriteLine(result);
                        break;

                    case "Add":
                        writer.WriteLine("Input numbers");

                        string[] addNumbers = reader.ReadLine().Split(' ');
                        int num3 = int.Parse(addNumbers[0]);
                        int num4 = int.Parse(addNumbers[1]);
                        string addResult = (num3 + num4).ToString();
                        writer.WriteLine(addResult);
                        break;

                    case "Subtract":
                        writer.WriteLine("Input numbers");

                        string[] subtractNumbers = reader.ReadLine().Split(' ');
                        int num5 = int.Parse(subtractNumbers[0]);
                        int num6 = int.Parse(subtractNumbers[1]);
                        string subtractResult = (num5 - num6).ToString();
                        writer.WriteLine(subtractResult);
                        break;

                }

            }

            client.Close();

            
        }


    }
}
