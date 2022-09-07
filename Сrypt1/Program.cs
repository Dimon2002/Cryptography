namespace KeyEncryption;

public class Program
{
    const string str = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    public static void Main()
    {
        Key key = new(str);

        using StreamWriter sw = new("../../../KeyEncryption.txt");

        var dict = key.KeyValuePairs();

        // Не знаю... мне не нравиться такая хуйня,
        // но и в конце лишняя строка в файле смотриться как дерьмо,
        // но я не в курсах как это пофиксить
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