using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task_1;
using Task_1.Models;
using Task_1.Services;
using Task_1.View;

SeedData.Manager.AddToFirstGroup(SeedData.WestEastTrafficLight);
SeedData.Manager.AddToFirstGroup(SeedData.EastWestTrafficLight);
SeedData.Manager.AddToSecondGroup(SeedData.SouthNorthTrafficLight);
SeedData.Manager.AddToSecondGroup(SeedData.NorthSouthTrafficLight);

var timings = ConsoleView.SetConfigParamsMenu();

var simulator = new TrafficSimulatorService(timings.i, SeedData.Manager, SeedData.View);

simulator.ChangeTimings(timings.p1, timings.p2);  //Зробив через метод а не конструктор, щоб можна було змінювати в рантаймі при необхідності в майбутньому
simulator.StartSimulation();

//Push any key to force exit
Console.ReadKey();              //Коллектор знищує об'єкти таймерів при закінченні мейна (так як вони в інших потоках працюють) тому треба затримати мейн



