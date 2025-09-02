public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // SOLUTION

        // Use number of multiples provided as input to create an array with the lenght equal the input.
        var multiplesArray = new double[length];
        
        // Create a loop with the starting number with the multiples, both provided as input
        for (var i = 1; i <= length; i++)
        {

        // multiple the number by the multiple of the loop
        var multipleOf = number * i;

        // Save the result in the array
            multiplesArray[i-1] = multipleOf;
        }

        // return the array
        return multiplesArray; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>

    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // SOLUTION

        // Get the length of the list
        var count = data.Count;

        // Extract the last elements of the list and store them in a temporary list.
        var lastElem = data.GetRange(count - amount, amount);

        // Extract the first elements of the list and store them in a temporary list.
        var firstElem = data.GetRange(0, count - amount);

        // Clear the list
        data.Clear();

        // Add the last elements in the beggining
        data.AddRange(lastElem);

        // Add the first elements in the end.
        data.AddRange(firstElem);
    }
}
