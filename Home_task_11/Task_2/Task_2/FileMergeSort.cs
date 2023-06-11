using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2;

public static class FileMergeSort
{
    public static void MergeSort(string inputFilename, int dataCount, int maxArraySize)
    {
        MergeSortRecursive(0, dataCount - 1, maxArraySize);
    }

    static void MergeSortRecursive(int left, int right, int maxArraySize)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            if (right - left + 1 > maxArraySize)
            {
                MergeSortRecursive(left, mid, maxArraySize);
                MergeSortRecursive(mid + 1, right, maxArraySize);
            }
            else
            {
                InsertionSort(left, right);
            }
            Merge(left, mid, right);
        }
    }

    static void Merge(int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; ++i)
        {
            L[i] = FileHelper.GetByIndex(left + i);
            //L[i] = arr[left + i];
        }


        for (int j = 0; j < n2; ++j)
        {
            R[j] = FileHelper.GetByIndex(mid + 1 + j);
            //R[j] = arr[mid + 1 + j];
        }


        int p = 0, q = 0;
        int k = left;
        while (p < n1 && q < n2)
        {
            if (L[p] <= R[q])
            {
                FileHelper.SetByIndex(k, L[p]);
                //arr[k] = L[p];
                p++;
            }
            else
            {
                FileHelper.SetByIndex(k, R[q]);
                //arr[k] = R[q];
                q++;
            }
            k++;
        }

        while (p < n1)
        {
            FileHelper.SetByIndex(k, L[p]);
            //arr[k] = L[p];
            p++;
            k++;
        }

        while (q < n2)
        {
            FileHelper.SetByIndex(k, R[q]);
            //arr[k] = R[q];
            q++;
            k++;
        }
    }

    static void InsertionSort(int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            //int key = arr[i];
            int key = FileHelper.GetByIndex(i);
            int j = i - 1;
            while (j >= left && /*arr[j]*/FileHelper.GetByIndex(j) > key)
            {
                FileHelper.SetByIndex(j + 1, FileHelper.GetByIndex(j));
                //arr[j + 1] = arr[j];
                j--;
            }
            FileHelper.SetByIndex(j + 1, key);
            //arr[j + 1] = key;
        }
    }
}
