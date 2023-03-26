using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestHorizontalLineFinder;

internal class MatrixColorLineInfoModel
{
    public int MatrixLineIndex { get; set; }
    public (int x, int y) StartPoint { get; set; }
    public (int x, int y) EndPoint { get; set; }
    public int Length { get; set; }
    public int Color { get; set; }

    public override string ToString()
    {
        string result = "Longest color line:\n";
        result += $"\t - Row index in matrix: {MatrixLineIndex}\n";
        result += $"\t - Color: {Color}\n";
        result += $"\t - Start point: ({StartPoint.x}, {StartPoint.y})\n";
        result += $"\t - End point: ({EndPoint.x}, {EndPoint.y})\n";
        result += $"\t - Line length: {Length}";
        return result; 
    }
}
