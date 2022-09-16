using KeyEncryption;

namespace Cryptographer;
public class Program
{
    public static void Main()
    {
        using StreamReader KeyReader = new("../../../../Сrypt1/KeyEncryption.txt");
        using StreamReader TextReader = new("../../../Text.txt");
        using StreamWriter TextEncryptWriter = new("../../../OutText.txt");

        var key = new Key(KeyReader.ReadToEnd().Split("\r\n"));
        var text = TextReader.ReadToEnd();

        Encrypter encrypter = new(key);

        TextEncryptWriter.Write(encrypter.Encrypt(text));
    }
}
