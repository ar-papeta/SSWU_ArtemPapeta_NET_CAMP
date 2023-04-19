using Task_2.Controllers;
using Task_2.Views;

IView ConsoleView = new ConsoleView(new ShopService());

ConsoleView.ShowMenu();