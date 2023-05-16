using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Models.Sections;
public enum SectionType
{
    Default,
    LeftTurn,
    RightTurn,
    StraightOnly,
}

public class GreenSection : Section
{
    public SectionType Type { get; set; }
    public GreenSection(SectionType type)
    {
        Type = type;
        Color = SectionColor.Green;
        State = SectionState.Off;
    }
}
