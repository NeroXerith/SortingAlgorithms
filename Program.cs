using System;
using System.Globalization;

class Program
{
    static int[] numArr;

    static void Main(string[] args)
    {
        int n = GetMaxArraySize();
        numArr = GetNumbers(n);

        int[] sortedArr = SortNumbers();
        Console.WriteLine("\nUnsorted Data:");
        DisplayNumbersWithCommas(numArr);
        Console.WriteLine("\nSorted Data:");
        DisplayNumbersWithCommas(sortedArr);

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

    static int[] GetNumbers(int n)
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

    static int[] SortNumbers()
    {
        int[] arr = new int[numArr.Length];
        numArr.CopyTo(arr, 0);

        while (true)
        {
            try
            {
                Console.WriteLine("\n\n|-- High to Low (1) || Low to High (2) --|");
                int option = int.Parse(Console.ReadLine());

                if (option != 1 && option != 2)
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

                if (option == 1)
                {
                    SortHighToLow(arr);
                }
                else if (option == 2)
                {
                    SortLowToHigh(arr);
                }

                return arr;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }

    static void SortHighToLow(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] < arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static void SortLowToHigh(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
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
}
