namespace Сrypt2.DiffieHellman.GenerationKey;

using static Math;
public class KeyGeneration
{
    public readonly ulong p;
    public readonly ulong g;
    
    public ulong a { get; private set; }

    public KeyGeneration(ulong p, ulong g)
    {
        this.p = p;
        this.g = g;
    }

    public KeyGeneration() : base() { }

    #region Проверка на простоту числа p
    public bool IsPrime()
    {
        if (p < 2) return false;

        for (ulong i = 2; i <= Truncate(Sqrt(p)); ++i)
            if (p % i == 0) return false;
        return true;
    }
    #endregion

    #region Проверка g на первообразный корень
    public bool IsPrimitive()
    {
        var tmp = p - 1;

        if (BinaryPower(g, tmp) != 1) return false;

        for (ulong i = 2; i < Truncate(Sqrt(tmp)); ++i)
        {
            if (tmp % i == 0)
            {
                if (BinaryPower(g, i) == 1 || BinaryPower(g, tmp / i) == 1)
                    return false;
            }
        }
        return true;
    }
    #endregion

    #region Быстрое возведение в степень по модулю
    public ulong BinaryPower(ulong b, ulong e)
    {
        ulong v = 1;
        while (e != 0)
        {
            if ((e & 1) != 0)
            {
                v *= b;
                v %= this.p;
            }
            b *= b;
            b %= this.p;
            e >>= 1;
        }
        return v;
    }
    #endregion

    #region Вычисление A
    public ulong PublicKey(int seed)
    {
        this.a = RandomValue(seed);
        return BinaryPower(g, a);
    }
    #endregion

    #region Случайное число в диапазоне от 1..(p - 1)
    private ulong RandomValue(int seed)
    {
        Random rnd = new(seed);
        return Convert.ToUInt64(rnd.Next(1, Convert.ToInt32(p - 1)));
    }
    #endregion
}