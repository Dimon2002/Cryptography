using System.Net.Sockets;
using System.Text;

using Сrypt2.DiffieHellman.GenerationKey;

namespace Client
{
    public class Client
    {
        static void Main()
        {
            try
            {
                TcpClient tcpClient = new("127.0.0.1", 7000);

                NetworkStream stream = tcpClient.GetStream();

                byte[] bytesRead = new byte[64];
                int length = stream.Read(bytesRead, 0, bytesRead.Length);
                var answer = Encoding.ASCII.GetString(bytesRead, 0, length);
                string[] l = answer.Split(' ');

                var value1 = UInt64.Parse(l[0]);
                var value2 = UInt64.Parse(l[1]);

                KeyGeneration key = new(value1, value2);

                var PublicKeyB = key.PublicKey(71);

                // Отправляем B
                string request = PublicKeyB.ToString();
                byte[] bytesWrite = Encoding.ASCII.GetBytes(request); ;
                stream.Write(bytesWrite, 0, bytesWrite.Length);
                stream.Flush();

                Console.WriteLine("b = " + key.a);
                var secret = key.BinaryPower(Convert.ToUInt64(l[2]), key.a);
                Console.WriteLine("Secret = " + secret);

                Console.WriteLine("Enter to finish!");
                Console.ReadKey();

                tcpClient.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);  
            }
            Console.ReadKey();
 
        }
    }
}