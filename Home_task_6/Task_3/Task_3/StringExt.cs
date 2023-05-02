using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3;

public static class StringExt
{
    public static char[] TextSeparators = {' ', '\t' };
    public static IEnumerable<string> UniqueWords(this string text)
    {// у такій реалізації дійсно не має сенсу, тому що Ви вже повністю згенерували послідовність, а тоді починаєте по одному викидати, а треба викидати елемент під час генерації
        return text.Split(TextSeparators, StringSplitOptions.RemoveEmptyEntries).GroupBy(x => x).Where(x => x.Count() == 1).Select(i => i.Key);
        // yield return інкапсульовано в linq вираз

        //Не має абсолютно ніякого сенсу (робимо одне і теж 2 рази)
        //Але в умові задачі треба використати  yield return
        //тому залишу це тут :)
        //foreach (var word in words) 
        //{
        //    yield return word;
        //}
    }
        
}
