using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Models;

namespace Task_3.View;

internal interface IElectricityQuarterInfoView
{
    public void ShowFullReport();
    public void ShowSingleConsumerReport(ConsumerModel consumer);
    public void ShowFlatsNoWithoutConsamption();
    public void ShowBiggestDebtLastname();
    public void ShowDaysAfterLastReading();
}
