namespace Crypt_2
{
    static public class Reader
    {
        static public List<long> ConsoleRead()
        {
            return Console.ReadLine().
                Replace("(", "").Replace(")", "").Replace(",", "")
                .Split(" ").Select(x => Convert.ToInt64(x)).ToList();
        }

        static public long PlainTextRead()
        {
            return Convert.ToInt64(Console.ReadLine());
        }

        static public bool IsPrime(long number)
        {
            if (number < 2) return false;
            for (long i = 2; i * i <= number; i++)
                if (number % i == 0) return false;
            return true;
        }
    }
}
