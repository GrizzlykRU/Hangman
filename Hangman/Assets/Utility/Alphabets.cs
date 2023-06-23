using System;
using System.Collections.Generic;

namespace Utility
{
    public static class Alphabets
    {
        private static Dictionary<string, string> alphabets = new()
        {
            {"en", "abcdefghijklmopqrstuvwxyz"},
            {"ru", "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"}
        };

        public static string GetAlphabet(string language) => alphabets.ContainsKey(language) ? alphabets[language] : String.Empty;
    }
}