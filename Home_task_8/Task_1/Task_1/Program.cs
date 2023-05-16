using Task_1.Services;
using Task_1.TrafficLightBuilder;
using Task_1.View;


//Реалізував створення світлофора через патерн білдер
//По суті в 1 контроллер світлофорами можна вкладати світлофори різної конфігурації та типу (як і вимагалося в завданні)
//потенціально з різних перехресть і різних типів. (зараз їх можна відокремити по параметру NAME)
//Недоліки які я сам бачу, але щоб їх фіксити треба більше часу і дослідження предметної області:
//  -немає явного розділення світлофорів по групам (наприклад об'єднання в 1 перехрестя або явної роботи світлофорів в протифазі)
//  -тому випливає ще 1 недолік: вся відповідальність задання таймінгів лягає на кінцевого користувача
//  -треба розуміти, що сукупний таймінг роботи світлофора в межах 1 контролера повинен бути однаковий для всіх світлофорів

//Вся робота світлофорів в межах скоупу 1 контроллера зав'язана на різних тригерах подій в різний час загального таймлайну,
//кожен світлофор сам знає на які тригери в який час йому слід реагувати, а які ігнорувати.

//^ < > ці символи в консольному відображенні відповідають за зелене світло секцій тільки прямо, поворот ліворуч та праворуч відповідно. 
// можуть бути як доповнення до стану основної секції так і окремо, якщо основної (дефолтної) немає

try
{
    var tl1 = TrafficLights.Builder()
        .AddGreenBasicLight(TimeSpan.Zero, TimeSpan.FromSeconds(5))
        .AddYellowGRLight(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(7))
        .AddRedLight(TimeSpan.FromSeconds(7), TimeSpan.FromSeconds(10))
        .AddYellowRGLight(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(12))
        .AddRightTurnGreenLight(TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(5))
        .WithName("1: North South")
        .Build();

    var tl2 = TrafficLights.Builder()
        .AddRedLight(TimeSpan.Zero, TimeSpan.FromSeconds(5))
        .AddYellowRGLight(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(7))
        .AddGreenBasicLight(TimeSpan.FromSeconds(7), TimeSpan.FromSeconds(10))
        .AddYellowGRLight(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(12))
        .WithName("1: West East")
        .Build();

    var tl3 = TrafficLights.Builder()
       .AddGreenBasicLight(TimeSpan.Zero, TimeSpan.FromSeconds(6))
        .AddYellowGRLight(TimeSpan.FromSeconds(6), TimeSpan.FromSeconds(8))
        .AddRedLight(TimeSpan.FromSeconds(8), TimeSpan.FromSeconds(10))
        .AddYellowRGLight(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(12))
        .AddRightTurnGreenLight(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5))
        .WithName("2: South North")
        .Build();

    var tl4 = TrafficLights.Builder()
        .AddRedLight(TimeSpan.Zero, TimeSpan.FromSeconds(6))
        .AddYellowRGLight(TimeSpan.FromSeconds(6), TimeSpan.FromSeconds(8))
        .AddGreenBasicLight(TimeSpan.FromSeconds(8), TimeSpan.FromSeconds(10))
        .AddYellowGRLight(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(12))
        .WithName("2: East West")
        .Build();

    var tl_ = TrafficLights.Builder()
        .AddRedLight(TimeSpan.Zero, TimeSpan.FromSeconds(6))
        .AddStraightOnlyGreenLight(TimeSpan.FromSeconds(6), TimeSpan.FromSeconds(12))
        .WithName("Single line tl")
        .Build();


    var controller = new TrafficLightsController();
    controller.AddTrafficLigthsToControl(tl1);
    controller.AddTrafficLigthsToControl(tl2);
    controller.AddTrafficLigthsToControl(tl_);
    controller.AddTrafficLigthsToControl(tl3);
    controller.AddTrafficLigthsToControl(tl4);

    IView View = new ConsoleView();

    var simulator = new TrafficSimulatorService(20, controller, View);
    simulator.StartSimulation();
}
catch(Exception ex) //catch and hanlde all validation exception here TODO: catch exceptions by type in different catches!!!
{
    //implement reaction on exception
}

//Push any key to force exit
Console.ReadKey();              //Коллектор знищує об'єкти таймерів при закінченні мейна (так як вони в інших потоках працюють) тому треба затримати мейн



