namespace Crypt_2
{
    static public class Computer
    {

        static public long GenerateExp(long lambdaN)
        {
            Random random = new Random();
            long exp;
            do
            {
                exp = random.NextInt64(1, lambdaN);
            } while (!IsMutuallySimple(exp, lambdaN));

            return exp;
        }

        static public long ComputeD(long exp, long lambdaN)
        {
            var m = lambdaN;
            long y = 0, d = 1;

            if (lambdaN == 1)
                return 0;

            while (exp > 1)
            {
                long q = exp / lambdaN;

                long t = lambdaN;

                lambdaN = exp % lambdaN;
                exp = t;
                t = y;

                y = d - q * y;
                d = t;
            }

            if (d < 0)
                d += m;

            return d;
        }
        static public long ComputeN(long p, long q)
        {
            return p * q;
        }

        static public long ComputeLambdaN(long p, long q)
        {
            return LCM(p, q);
        }
        static public bool IsMutuallySimple(long exp, long lambdaN)
        {
            return GCD(exp, lambdaN) == 1;
        }

        static public long GCD(long p, long q)
        {
            if (p == 0)
            {
                return q;
            }
            var min = p < q ? p : q;
            var max = p > q ? p : q;
            return GCD(max % min, min);
        }
        static public long LCM(long p, long q)
        {
            return (p * q) / GCD(p, q);
        }
    }
}
