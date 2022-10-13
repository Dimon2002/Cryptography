using System.Net;
using System.Net.Sockets;
using System.Text;

using Сrypt2.DiffieHellman.GenerationKey;

namespace ClientServer
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the number p, which will be simple");
            _ = ulong.TryParse(Console.ReadLine(), out ulong p);

            Console.WriteLine("Enter the number g, which will be the primitive root of p");
            _ = ulong.TryParse(Console.ReadLine(), out ulong g);

            if (p == 0) { Console.WriteLine("p is not a natural number!"); Console.ReadKey(); return; }
            if (g == 0) { Console.WriteLine("q is not a natural number!"); Console.ReadKey(); return; }

            KeyGeneration keyGeneration = new(p, g);

            if (!keyGeneration.IsPrime()) { Console.WriteLine("p is not a prime nubmer!"); Console.ReadKey(); return; }
            if (!keyGeneration.IsPrimitive()) { Console.WriteLine("g is not a primitive number modulo p"); Console.ReadKey(); }

            var PublicKeyA = keyGeneration.PublicKey(111);
            Console.WriteLine("\np = " + keyGeneration.p);
            Console.WriteLine("g = " + keyGeneration.g);
            Console.WriteLine("a = " + keyGeneration.a);
            Console.WriteLine("\nSend A = " + PublicKeyA);

            try
            {
                TcpListener tcpListener = new(IPAddress.Any, 7000);
                tcpListener.Start();

                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                NetworkStream stream = tcpClient.GetStream();

                var y1 = Encoding.ASCII.GetBytes(p.ToString() + " ");
                var y2 = Encoding.ASCII.GetBytes(g.ToString() + " ");
                var y3 = Encoding.ASCII.GetBytes(PublicKeyA.ToString() + " ");

                stream.Write(y1, 0, y1.Length);
                stream.Write(y2, 0, y2.Length);
                stream.Write(y3, 0, y3.Length);
                stream.Flush();

                byte[] bytesRead = new byte[64];
                int length = stream.Read(bytesRead, 0, bytesRead.Length);
                var PublicKeyB = Convert.ToUInt64(Encoding.ASCII.GetString(bytesRead, 0, length));
                Console.WriteLine("Got B = " + PublicKeyB);


                var secret = keyGeneration.BinaryPower(PublicKeyB, keyGeneration.a);
                Console.WriteLine("Secret = " + secret);

                Console.WriteLine("Enter to finish!");
                Console.ReadKey();

                tcpClient.Close();
                tcpListener.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}