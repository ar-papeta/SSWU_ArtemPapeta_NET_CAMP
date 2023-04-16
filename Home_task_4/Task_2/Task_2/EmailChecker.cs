using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2;

internal class EmailChecker
{
    private List<string> _emails;

    private char[] _allowedCharacters = { '!', '#', '$', '%', '&', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'};
    private char[] _splitChars = { '\n', '\t'};

    public EmailChecker(List<string> emails)
    {
        _emails = emails;
    }
    public EmailChecker(string text)
    {
        _emails = text.Split(_splitChars).ToList();
    }


    public List<string> GetCorrectEmailsList()
    {
        List<string> correctEmails = new();
        foreach (string email in _emails) 
        {
            if (IsCorrectMail(email))
            {
                correctEmails.Add(email);
            }
        }
        return correctEmails;
    }

    public bool IsCorrectMail(string emailCandidate)
    {
        if(emailCandidate is null)
        {
            return false;
        }
        try
        {
            RemoveCommentsFromEmailCheck(ref emailCandidate);

            var (localPart, domainPart) = SplitToLocalAndDomain(emailCandidate);
        
            bool isLocalValid = LocalPartChecks(localPart);

            bool isDomainValid = DomainPartChecks(domainPart);

            return isLocalValid && isDomainValid;
        }
        catch (ValidationException)
        {
            return false;
        }
    }

    private bool LocalPartChecks(string localPart)
    {
        if (IsLocalCorrectQuoted(localPart))
        {
            return localPart[1..(localPart.Length - 2)].IndexOfAny(new char[] {'"', '\\'}) == -1;
        }

        foreach (var c in localPart)
        {
            if(!(char.IsAsciiLetterOrDigit(c) || _allowedCharacters.Contains(c)))
            {
                return false;
            }
        }

        if (!DotLocalChecks(localPart))
        {
            return false;
        }

        return true;
    }

    private bool DotLocalChecks(string localPart)
    {
        bool containsDuplicatesDot = localPart.Where((c, i) => c == '.' && i > 0 && c == localPart[i - 1])
                           .Cast<char?>()
                           .FirstOrDefault() != null
                           ;

        return !(localPart[0] == '.' || localPart[^1] == '.' || containsDuplicatesDot);
    }

    

    private bool DomainPartChecks(string domainPart)
    {
        if (domainPart[0] == '[' && domainPart[^1] == ']')
        {
            return IsStringValidIp(domainPart[1..(domainPart.Length - 2)]);
        }
        if(domainPart.Count(c => c == '.') > 1)
        {
            return false;
        }

        foreach (var c in domainPart)
        {
            if (!(char.IsAsciiLetterOrDigit(c) || c == '-' || c == '.') || domainPart[0] == '-' || domainPart[^1] == '-')
            {
                return false;
            }
        }

        return true;
    }

    private bool IsLocalCorrectQuoted(string localPart)
    {
        var count = localPart.Count(c => c == '"');

        return (count == 2) && localPart.IndexOf('"') == 0 && localPart.LastIndexOf('"') == localPart.Length - 1;
        
    }
    private void RemoveCommentsFromEmailCheck(ref string emailCandidate)
    {
        var openIndex = emailCandidate.IndexOf('(');

        if(openIndex == -1)
        {
            return;
        }
        var commentCount = emailCandidate.Count(c => c == ')');
        for (int i = 0; i < commentCount; i++)
        {
            var closedIndex = emailCandidate.IndexOf(')');
            emailCandidate = emailCandidate[..openIndex] + emailCandidate[(closedIndex + 1)..];
            openIndex = emailCandidate.IndexOf('(');

            if(openIndex == -1 && commentCount != i + 1)
            {
                throw new ValidationException("Email have wrong format coments");
            }
        }
    }

    

    private (string local, string domain) SplitToLocalAndDomain(string emailCandidate)
    {

        var separatorIndex = emailCandidate.LastIndexOf('@');
        if(separatorIndex == -1)
        {
            throw new ValidationException("Email have noone @");
        }
        
        return (emailCandidate[..separatorIndex], emailCandidate[(separatorIndex + 1)..]);
    }

    private bool IsStringValidIp(string ip)
    {
        if (ip.StartsWith("IPv6:"))
        {
            ip = ip[5..];
        }
        Regex validateIPv6Regex = new ("^(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))$");
        Regex validateIPv4Regex = new ("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
        return validateIPv4Regex.IsMatch(ip) || validateIPv6Regex.IsMatch(ip);  
    } 
}
