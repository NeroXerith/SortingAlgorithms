using System;
using System.Globalization;

public class Bubble
{
    static int[] numArr;

    public void BubbleSort()
    {
        int n = GetMaxArraySize();
        numArr = GetUserInput(n);

        int[][] simulations = new int[n * n][]; // Use a normal array to store the simulations

        int[] sortedArr = SortNumbers(simulations);
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

    static int[] SortNumbers(int[][] simulations)
    {
        int[] arr = new int[numArr.Length];
        numArr.CopyTo(arr, 0);

        int simulationCounter = 0; // Initialize the simulation counter

        for (int i = 0; i < arr.Length - 1; i++)
        {
            // Store the current state of the array in simulations array
            simulations[simulationCounter] = new int[arr.Length];
            arr.CopyTo(simulations[simulationCounter], 0);

            bool swapped = false; // Track if any swaps were made in this pass

            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            // If no swaps were made in this pass, the array is already sorted
            if (!swapped)
            {
                break;
            }

            simulationCounter++; // Increment the simulation counter
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
        int totalSimulations =0;
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
