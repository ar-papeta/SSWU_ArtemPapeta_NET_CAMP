using System.Globalization;
using System.Text;
using Task_1;

//CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
Console.OutputEncoding = Encoding.UTF8;

List<string> stringsEn = new()
{
    "A(d)daa.",
    "Asdasd< sfsdfsd safdas",
    "Sasd (asd) asd!",
    "(asd asd,",
    "asd wqer rqr nhgj)",
    "123 445 gasg?",
    "213vfertgf tergteqr qqrewq (eqwe fasd).",
};

List<string> stringsUa = new()
{
    "фівафві.",
    "йукук укейуц цйукй цуйк",
    "йцкуйцу йцукйук йцук (фіавфі)!",
    "(йцкцйукб цйукб  , цукц     ",
    "йуцк йцку йцук фівафіва)",
    "123 445 12344?",
    "1йкуй фіовл фіугцйш щйщ (фіваіф віаів) іваіва іваю.",
};

SentenceFinder finder = new(stringsUa);
try
{
    var strings = finder.FindSentencesWithBrackets();
    foreach (var item in strings)
    {
        Console.WriteLine(item);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("-------------------");

SentenceFinder finder2 = new(stringsEn);
try
{
    var strings2 = finder2.FindSentencesWithBrackets();
    foreach (var item in strings2)
    {
        Console.WriteLine(item);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
