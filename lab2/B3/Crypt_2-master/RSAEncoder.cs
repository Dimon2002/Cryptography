namespace Crypt_2
{
    static public class RSAEncoder
    {
        static public long Encode(long plainText, long n, long exp)
        {
            return (long)Power.FastModPow(plainText, exp, n);
        }
    }
}
