using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2;

internal static class MatrixEnumerator 
{
    public static IEnumerable<int> EnumerateMatrix(params int[][] nums)
    {
        if(nums is null || nums.Length == 0)
        {
            yield break;
        }
        var resArr = nums.Aggregate((arr, arrNext) => arr.Concat(arrNext).Order().ToArray());
        for (int i = 0; i < resArr.Length; i++)
        {
            yield return resArr[i];
        }
        
    }
}
