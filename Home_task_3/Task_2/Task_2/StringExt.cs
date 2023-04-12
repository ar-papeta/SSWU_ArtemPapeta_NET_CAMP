using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2;

internal static class StringExt
{
    public static int FirstCapitalLetterWordCount(this string input) => 
        input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0])).Count();
    

    public static int? SecondIndexOf(this string input, string subString)
    {
        var index = input.IndexOf(subString, input.IndexOf(subString) + 1);

        return index == -1 ? null : index;
    }
// тут є проблема. Можемо обговорити...
    public static string SwapDoubleLettersTo(this string input, string text)
    {
        return input.Split(' ')
                .Select(x =>
                    x.Where((c, i) => i > 0 && c == x[i - 1]).Cast<char?>().FirstOrDefault() is not null ? x.Replace(x, text) : x)
                .Aggregate((s1, s2) => string.Format("{0} {1}", s1, s2)); 
    }
}
