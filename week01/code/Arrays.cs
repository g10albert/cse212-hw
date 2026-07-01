using System;
using System.Collections.Generic;
public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {

        if (data == null || data.Count <= 1 || amount == data.Count)
        {
            return;
        }

        int splitIndex = data.Count - amount;

        List<int> backSegment = data.GetRange(splitIndex, amount);

        data.RemoveRange(splitIndex, amount);

        data.InsertRange(0, backSegment);
    }
}
