namespace KeyEncryption;
public class Key
{
    private readonly Dictionary<char, char> _keyValuePairs = new();
    public char this[char item] => _keyValuePairs[item];

    public Key(string str, int seed = 1)
    {
        List<char> ChangeAlph = Shuffle(str.ToList(), seed);

        for (int i = 0; i < ChangeAlph.Count; i++)
            _keyValuePairs.Add(str[i], ChangeAlph[i]);
    }
    public Key(string[] KeysPairs)
    {
        foreach (var item in KeysPairs)
                _keyValuePairs.Add(item[1], item[4]);
    }
    public Key() { }

    private static List<char> Shuffle(List<char> Alph, int seed)
    {
        Random rnd = new(seed);

        for (int i = Alph.Count - 1; i >= 1; --i)
        {
            int j = rnd.Next(0, i);
            (Alph[j], Alph[i]) = (Alph[i], Alph[j]);
        }
        return Alph;
    }

    public bool IsContains(char symbol) => _keyValuePairs.ContainsKey(symbol);
    public Dictionary<char, char> KeyValuePairs() => _keyValuePairs;
}