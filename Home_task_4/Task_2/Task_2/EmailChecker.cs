using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2;

public enum CheckResult
{
    Success,
    
}

internal class EmailChecker
{
    private string _emailCandidate;
    private string _localPart;
    private bool _isLocalInQuotation;
    private string _domainPart;

    private char[] _allowedCharacters = { '!', '#', '$', '%', '&', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~'};
    public EmailChecker(string emailCandidate)
    {
        _emailCandidate = emailCandidate;
    }

    public bool IsCorrectMail()
    {
        if(_emailCandidate is null)
        {
            return false;
        }

        RemoveCommentsFromEmailCheck();

        SplitToLocalAndDomain();

        bool bl = LocalPartChecks();

        DomainPartChecks();

        return true; 
    }

    private bool LocalPartChecks()
    {
        if (IsLocalCorrectQuoted())
        {
            return _localPart[1..(_localPart.Length - 2)].IndexOfAny(new char[] {'"', '\\'}) == -1;
        }

        foreach (var c in _localPart)
        {
            if(char.IsAsciiLetterOrDigit(c) ||  )
        }
        return true;
    }

    

    private bool DomainPartChecks()
    {
        return true;
    }

    private bool IsLocalCorrectQuoted()
    {
        var count = _localPart.Count(c => c == '"');

        return (count == 2) && _localPart.IndexOf('"') == 0 && _localPart.LastIndexOf('"') == _localPart.Length-1;
        
    }
    private void RemoveCommentsFromEmailCheck()
    {
        var openIndex = _emailCandidate.IndexOf('(');

        if(openIndex == -1)
        {
            return;
        }
        var commentCount = _emailCandidate.Count(c => c == ')');
        for (int i = 0; i < commentCount; i++)
        {
            var closedIndex = _emailCandidate.IndexOf(')');
            _emailCandidate = _emailCandidate[..openIndex] + _emailCandidate[(closedIndex + 1)..];
            openIndex = _emailCandidate.IndexOf('(');

            if(openIndex == -1 && commentCount != i + 1)
            {
                throw new ValidationException("Email have wrong format coments");
            }
        }
    }

    private void SplitToLocalAndDomain()
    {

        var separatorIndex = _emailCandidate.LastIndexOf('@');
        if(separatorIndex == -1)
        {
            throw new ValidationException("Email have noone @");
        }
        _localPart = _emailCandidate[..separatorIndex];
        _domainPart = _emailCandidate[(separatorIndex + 1)..];
    }
}
