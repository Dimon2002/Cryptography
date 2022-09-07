using KeyEncryption;
using System.Text;

namespace Cryptographer;
public class Encrypter
{
    private readonly Key _key;

    public Encrypter (Key key)
    {
        _key = key;
    }

    public string Encrypt(string text)
    {
        StringBuilder EncryptedText = new(text.Length);

        foreach (var item in text.ToLower())
            if (_key.IsContains(item))
                EncryptedText.Append(_key[item]);

        return EncryptedText.ToString();
    }
}
