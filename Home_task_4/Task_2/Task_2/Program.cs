
using Task_2;

string EmailText =
    //valid
    "simple@example.com"
    + '\n'
    + "disposable.style.email.with+symbol@example.com"
    + '\n'
    + "example-indeed@strange-example.com"
    + '\n'
    + "\" \"@example.org"
    + '\n'
    + "\"john..doe\"@example.org"
    + '\n'
    + "mailhost!username@example.org"
    + '\n'
    + "admin@mailserver1"
    + '\n'
    + "(this .. is ( comment in email)simple@example.com(domain comment)"
    + '\n'
    + "postmaster@[123.123.123.123]"
    + '\n'
    + "postmaster@[IPv6:2001:0db8:85a3:0000:0000:8a2e:0370:7334]"
    +'\n'
    //invalid
    + "Abc.example.com"
    + '\n'
    + "A@b@c@example.com"
    + '\n'
    + "i_like_underscore@but_its_not_allow_in _this_part.example.com"
    + '\n'
    + "just\"not\"right@example.com";

EmailChecker checker = new(EmailText);
var list = checker.GetCorrectEmailsList();
foreach (var item in list)
{
    Console.WriteLine(item);
}
