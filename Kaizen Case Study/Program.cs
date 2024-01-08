using System;
using System.Collections.Generic;

class Program
{
    private static readonly char[] AllowedCharacters = { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z', '2', '3', '4', '5', '7', '9' };
    private static readonly int CodeLength = 8;

    static void Main(string[] args)
    {
        HashSet<string> codes = GenerateUniqueCodes(1000);

        foreach (var code in codes)
        {
            Console.WriteLine($"Code: {code}, IsValid: {CheckCode(code)}");
        }
    }

    private static HashSet<string> GenerateUniqueCodes(int numberOfCodes)
    {
        HashSet<string> codes = new HashSet<string>();
        Random random = new Random();

        while (codes.Count < numberOfCodes)
        {
            var code = GenerateCode(random);
            codes.Add(code);
        }

        return codes;
    }

    private static string GenerateCode(Random random)
    {
        char[] codeChars = new char[CodeLength];

        for (int i = 0; i < CodeLength; i++)
        {
            codeChars[i] = AllowedCharacters[random.Next(AllowedCharacters.Length)];
        }

        return new string(codeChars);
    }

    private static bool CheckCode(string code)
    {
        // Burada kodun yapısını kontrol eden algoritmayı tanımlayabiliriz.
        // Örneğin, belirli bir desen, hash veya hesaplama yöntemi kullanılabilir.
        // Bu örnekte basit bir yapısal kontrol yapılıyor.
        if (code.Length != CodeLength) return false;

        foreach (var ch in code)
        {
            if (Array.IndexOf(AllowedCharacters, ch) == -1)
                return false;
        }

        return true;
    }
}
