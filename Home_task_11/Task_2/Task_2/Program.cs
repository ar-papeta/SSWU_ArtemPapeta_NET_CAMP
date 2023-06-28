using System;
using System.IO;
using Task_2;

class Program
{
    static int DATA_COUNT = 100;
    static int RAM_ALLOWED = 50; //actually in my case we dont use ANY RAM to store data
    static void Main()
    {
        
        // Generate random integers
        int[] data = GenerateRandomIntegers(DATA_COUNT);

        // Save data to a file
        FileHelper.SaveDataToFile(data, "data.txt");

        // Sort the data using merge sort (WITHOUT ANY ARRAYS STORE IN RAM memory)
        FileMergeSort.MergeSort("data.txt", DATA_COUNT, RAM_ALLOWED);
    }

    static int[] GenerateRandomIntegers(int count)
    {
        int[] data = new int[count];
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            data[i] = random.Next(1000); // Generate random integers between 0 and 999
        }
        return data;
    }    
}
