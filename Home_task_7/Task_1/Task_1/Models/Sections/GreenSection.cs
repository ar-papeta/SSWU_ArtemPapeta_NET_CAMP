using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Models.Sections;
public enum SectionDirection
{
    Full,
}

public class GreenSection : Section
{
    public SectionDirection Direction { get; set; }
    public GreenSection(SectionDirection direction)
    {
        Direction = direction;
        Color = SectionColor.Green;
        State = SectionState.Off;
    }
}
