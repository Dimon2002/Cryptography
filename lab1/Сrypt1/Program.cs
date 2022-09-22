namespace KeyEncryption;

public class Program
{
    const string str = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    public static void Main()
    {
        Key key = new(str);

        using StreamWriter sw = new("../../../KeyEncryption.txt");

        var dict = key.KeyValuePairs();

        var count = dict.Count;
        foreach (var item in dict)
            if (count > 1)
            {
                sw.WriteLine(item);
                --count;
            }
            else sw.Write(item);

    }
}
