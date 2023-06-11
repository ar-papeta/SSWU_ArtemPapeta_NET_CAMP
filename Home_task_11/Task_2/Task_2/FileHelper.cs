using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2;

public static class FileHelper
{
    public static void SaveDataToFile(int[] data, string filename)
    {
        using StreamWriter writer = new(filename);
        foreach (int num in data)
        {
            writer.WriteLine(num);
        }
    }

    public static int[] ReadDataFromFile(string filename, int from, int to)
    {
        string[] lines = File.ReadLines(filename).Skip(from).Take(to - from).ToArray();
        int[] data = new int[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            data[i] = int.Parse(lines[i]);
        }

        return data;
    }


    public static int GetByIndex(int index, string fileName = "data.txt") 
        => Convert.ToInt32(File.ReadLines(fileName).Skip(index).First());

    public static void SetByIndex(int index, int value, string fileName = "data.txt") 
    {
        string[] lines = File.ReadAllLines(fileName);

        // Modify the desired line
        lines[index] = value.ToString();
        
        // Write the updated contents back to the file
        File.WriteAllLines(fileName, lines);
    }
}
