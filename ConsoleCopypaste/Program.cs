using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Reflection.Metadata.Ecma335;

partial class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Rgb(1, 2, 256));
    }
    
    static Dictionary<int, string> pairs = new Dictionary<int, string>()
    {
        {10, "A"},
        {11, "B"},
        {12, "C"},
        {13, "D"},
        {14, "E"},
        {15, "F"}
    };

    static string Rgb(int r, int g, int b)
    {
        r = Math.Clamp(r, 0, 255);
        g = Math.Clamp(g, 0, 255);
        b = Math.Clamp(b, 0, 255);

        return $"{ToXVI(r)}{ToXVI(g)}{ToXVI(b)}";
    }

    private static string ToXVI(int temp)
    {
        return GetNumber(temp / 16 % 16) + GetNumber(temp % 16);
    }

    static string GetNumber(int i)
    {
        if (pairs.ContainsKey(i))
        {
            return pairs[i];
        }
        return i.ToString();
    }
}
