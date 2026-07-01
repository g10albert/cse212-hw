using System;
using System.Collections.Generic;
public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {

        // Plan:
        // 1. Initialize a new array of doubles called 'result' with a size equal to the 'length' parameter.
        // 2. Create a for loop that iterates from 0 up to 'length - 1' using an index variable 'i'.
        // 3. Inside the loop, calculate the multiple for the current position. Since 'i' starts at 0, 
        //    multiply the base 'number' by (i + 1) to get the 1st, 2nd, 3rd, etc., multiples.
        // 4. Assign this calculated value to result[i].
        // 5. After the loop finished populating all elements, return the 'result' array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {

        // Plan:
        // 1. Check if the list needs rotation. If 'data' is null, contains 1 or fewer elements, or the 
        //    'amount' to rotate matches the list size (a full loop), return early without doing work.
        // 2. Determine the splitting index by subtracting 'amount' from the total count of elements (data.Count - amount).
        //    This marks where the elements that need to wrap around to the front begin.
        // 3. Use GetRange starting at this splitting index for 'amount' elements to copy the back segment into a temporary list.
        // 4. Use RemoveRange to delete those exact copied elements from the tail end of the original 'data' list.
        // 5. Use InsertRange to inject the temporary list of elements back into the original 'data' list at index 0.

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
