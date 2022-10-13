namespace Crypt_2
{
    public class RSADecoder
    {
        static public long Decode(long cipherText, long n, long d)
        {
            return (long)Power.FastModPow(cipherText, d, n);
        }
    }
}
