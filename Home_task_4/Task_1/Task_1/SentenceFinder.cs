
using System.Globalization;

namespace Task_1;
public enum Culture
{
    uk_UA = 0,
    en_US = 1,
}
internal class SentenceFinder
{
    private readonly List<string> _lines;
    private readonly char[] _textChars;
    private readonly char[] _sentenceSeparators = new char[] { '!', '.', '?'};
    private readonly char[] _openChars = new char[] { '(', '[', '{' };
    private readonly char[] _closedChars = new char[] { ')', ']', '}' };

    public SentenceFinder(List<string> lines)
    {
        _lines = lines;
        _textChars = _lines.Select(s => s.ToCharArray()).Aggregate((s1, s2) => s1.Concat(s2).ToArray());
    }
    public SentenceFinder(List<string> lines, char[] sentenceSeparators, char[] openChars, char[] closedChars)
    {
        _closedChars = closedChars;
        _sentenceSeparators = sentenceSeparators;
        _openChars = openChars;
        _lines = lines;
        _textChars = _lines.Select(s => s.ToCharArray()).Aggregate((s1, s2) => s1.Concat(s2).ToArray());
    }

    public List<string> FindSentencesWithBrackets()
    {
        int lastStartIndex = 0;
        int lastEndIndex = 0;
        List<string> strings = new();
        for (int i = 0; i < _textChars.Length; i++)
        {
            if (_openChars.Contains(_textChars[i]))
            {
                lastStartIndex = Array.FindIndex(_textChars, lastEndIndex, i - lastEndIndex, x => _sentenceSeparators.Contains(x));

                lastEndIndex = Array.FindIndex(_textChars, i, x => _sentenceSeparators.Contains(x));
                string sentence = new string(_textChars[(lastStartIndex + 1)..(lastEndIndex + 1)]).Trim();

                if(sentence.IndexOfAny(_closedChars) == -1)
                {
                    throw new Exception("Sentence have no closed char");
                }
                strings.Add(sentence);
            }
            //"Вважаємо що дужки в тексті розташовані правильно і немає вкладеності."
            //Тому не бачу алгоритмічного сенсу перевіряти чи закривається відкрита дужка в реченні
            //(завжди приймаю що так, згідно з вищецитованою стрічкою вашого ТЗ)
            //Крім того немає опису кейсу, що робити якщо дужка не закрилася до кінця речення 
            //Але все-таки добавлю перевірку :)
        }
        return strings;
    }
}
