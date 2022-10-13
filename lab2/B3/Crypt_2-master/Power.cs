using System.Numerics;

namespace Crypt_2
{
    static public class Power
    {
        static public BigInteger FastModPow(long number, long exp, long modulus)
        {
            if (exp == 0) return 1;
            BigInteger z = FastModPow(number, exp >> 1, modulus);
            if ((exp & 1) == 0)
            {
                return z * z % modulus;
            }
            return number * z * z % modulus;
        }
    }
}
