using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Models;

namespace Task_1;

public static class QuickSort<T>
{

    public static void SortRecursive(T[] array, Func<T, T, int> comparison, PivotType pivotType)
    {
        if (array == null || array.Length <= 1)
            return;

        SortArray(array, comparison, 0, array.Length - 1, pivotType);
    }

    private static T[] SortArray(T[] array, Func<T, T, int> comparison, int leftIndex, int rightIndex, PivotType pivotType)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[GetNewPivotFor(pivotType, leftIndex, rightIndex)];
        while (i <= j)
        {
            while (comparison(array[i], pivot) < 0)
            {
                i++;
            }

            while (comparison(array[j], pivot) > 0)
            {
                j--;
            }
            if (i <= j)
            {
                (array[j], array[i]) = (array[i], array[j]);
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            SortArray(array, comparison, leftIndex, j, pivotType);
        if (i < rightIndex)
            SortArray(array, comparison, i, rightIndex, pivotType);
        return array;
    }

    private static int GetNewPivotFor(PivotType pivotType, int first, int last) => pivotType switch
    {
        PivotType.Last => last,
        PivotType.First => first,
        PivotType.Median => (last - 1) / 2 > first ? (last - 1) / 2 : first,
        PivotType.Random => new Random().Next(first, last + 1)
    };





}
