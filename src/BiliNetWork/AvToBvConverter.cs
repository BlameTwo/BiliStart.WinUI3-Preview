/*
 这里的转换方法是来自于网络上的python代码，我不懂python，使用ChatGpt进行辅助翻译了一下。
 （诚实
 */


namespace BiliNetWork;

public class AvToBvConverter : IAvToBvConverter
{
    private string table = "fZodR9XQDSUm21yCkr6zBqiveYah8bt4xsWpHnJE7jL5VG3guMTKNPAwcF";
    private int[] s = { 11, 10, 3, 8, 4, 6 };
    private int xor = 177451812;
    private long add = 8728348608L;
    private Dictionary<string, int> number2Word;

    public AvToBvConverter()
    {
        number2Word = new Dictionary<string, int>();
        for (int i = 0, size = table.Length; i < size; i++)
        {
            number2Word[getIndex(table, i)] = i;
        }
    }

    private string getIndex(string str, int index)
    {
        return str.Substring(index, 1);
    }

    private string topOffIndex(string before, string updated, int index)
    {
        return before.Substring(0, index) + updated + before.Substring(index + 1);
    }

    public string Enc(long x)
    {
        x = (x ^ xor) + add;
        string r = "BV1  4 1 7  ";

        for (int i = 0; i < 6; i++)
        {
            r = topOffIndex(r, getIndex(table, (int)((x / Math.Pow(58, i)) % 58)), s[i]);
        }
        return r;
    }

    public long Dec(string x)
    {
        long r = 0;
        for (int i = 0; i < 6; i++)
        {
            r += (long)number2Word[getIndex(x, s[i])] * (long)Math.Pow(58, i);
        }
        return (r - add) ^ xor;
    }
}
