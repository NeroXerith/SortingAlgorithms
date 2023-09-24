using System;
using System.Globalization;

public class Bubble
{
    static int[] numArr;

    public void BubbleSort()
    {
        int n = GetMaxArraySize(); // Ask the user for Max input
        numArr = GetUserInput(n);

        bool isAscending = GetSortOrder(); // Ask the user for sorting order

        int[][] simulations = new int[n * n][];
        int[] sortedArr = SortNumbers(simulations, isAscending);

        Console.WriteLine("\nUnsorted Data:");
        DisplayNumbersWithCommas(numArr);

        Console.WriteLine("\nSorted Data:");
        DisplayNumbersWithCommas(sortedArr);

        Console.WriteLine("\nSort Simulations:");
        DisplaySortSimulations(simulations);

        Console.Read();
    }

    static int GetMaxArraySize()
    {
        int maxInput = 0;

        while (true)
        {
            try
            {
                Console.Write("Max Input: ");
                maxInput = int.Parse(Console.ReadLine());

                if (maxInput <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    continue;
                }

                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        return maxInput;
    }

    static int[] GetUserInput(int n)
    {
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n|--- Input #{i + 1} ---|");

            while (true)
            {
                try
                {
                    Console.Write("Input Number: ");
                    arr[i] = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }

        return arr;
    }

    static bool GetSortOrder()
    {
        while (true)
        {
            Console.WriteLine("\n\n|-- High to Low (1) || Low to High (2) --|");
            Console.Write("Input Number: ");
            string sortOrder = Console.ReadLine();

            if (sortOrder == "1")
            {
                return true; // Ascending order
            }
            else if (sortOrder == "2")
            {
                return false; // Descending order
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
            }
        }
    }

    static int[] SortNumbers(int[][] simulations, bool isAscending)
    {
        int[] arr = new int[numArr.Length];
        numArr.CopyTo(arr, 0);

        int simulationCounter = 0;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            simulations[simulationCounter] = new int[arr.Length];
            arr.CopyTo(simulations[simulationCounter], 0);

            bool swapped = false;

            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (isAscending ? arr[j] > arr[j + 1] : arr[j] < arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }

            simulationCounter++;
        }

        return arr;
    }

    static void DisplayNumbersWithCommas(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i].ToString("N0", CultureInfo.InvariantCulture));

            if (i < arr.Length - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
    }

    static void DisplaySortSimulations(int[][] simulations)
    {
        int totalSimulations = 0;
        for (int i = 0; i < simulations.Length; i++)
        {
            if (simulations[i] != null)
            {
                Console.Write($"Simulation [{i}]: ");
                DisplayNumbersWithCommas(simulations[i]);
                totalSimulations++;
            }
        }

        Console.WriteLine($"\nTotal simulations: {totalSimulations}");
    }
}
