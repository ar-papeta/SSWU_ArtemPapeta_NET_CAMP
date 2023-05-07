using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Models.Sections;

public class YellowSection : Section
{
    public YellowSection()
    {
        Color = SectionColor.Yelow;
        State = SectionState.Off;
    }
}
