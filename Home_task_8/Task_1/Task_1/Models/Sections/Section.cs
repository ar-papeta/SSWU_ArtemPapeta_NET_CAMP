using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Models.Sections;

public enum SectionState
{
    Off,
    On,
    Blinking
}

public enum SectionColor
{
    Red,
    Yelow,
    Green,
}


public class Section
{
    public SectionState State { get; set; }
    public SectionColor Color { get; set; }

}
