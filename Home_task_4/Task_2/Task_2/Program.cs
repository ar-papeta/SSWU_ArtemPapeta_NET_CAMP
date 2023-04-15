// See https://aka.ms/new-console-template for more information
using Task_2;

Console.WriteLine("Hello, World!");

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
    + "(this is ( comment in email)simple@example.com(domain comment)"
    + '\n'
    + '\n'
    + '\n'
    //invalid
    + "Abc.example.com"
    + '\n'
    + "A@b@c@example.com"
    + '\n'
    + "i_like_underscore@but_its_not_allow_in _this_part.example.com"
    + '\n'
    + "just\"not\"right@example.com";

string s = "\"simple\"@example.com";
EmailChecker checker = new EmailChecker(s);
checker.IsCorrectMail();