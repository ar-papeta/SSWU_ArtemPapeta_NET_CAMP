// See https://aka.ms/new-console-template for more information

using Task_3;
using Task_3.BL;
using Task_3.View;
// Останній стовпець погано форматований.
var model = ElectricityQuarterInfoParser.ParseModelFromText(SeedData.FirstQuarterData);

IElectricityQuarterInfoView view = new ElectricityQuarterInfoViewConsole(new(model));

view.ShowFullReport();

view.ShowSingleConsumerReport(model.Consumers[3]);

view.ShowBiggestDebtLastname();

view.ShowFlatsNoWithoutConsamption();

view.ShowDaysAfterLastReading();

