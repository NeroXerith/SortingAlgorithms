using System;

class Program
{
    static void Main(string[] args)
    {
        string[] sortingAlgo = { "Bubble Sort", "Insertion Sort", "Selection Sort", "Merge Sort" };

        Console.WriteLine("Choose your Sorting algorithm");

        for (int i = 0; i < sortingAlgo.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {sortingAlgo[i]}");
        }

        int userInput = GetUserInput();

        switch (userInput)
        {
            case 1:
                Bubble bubbleSort = new Bubble();
                bubbleSort.BubbleSort();
                break;
            case 2:
                Insertion insertionSort = new Insertion();
                insertionSort.InsertionSort();
                break;
            case 3:
                Selection selectionSort = new Selection();
                selectionSort.SelectionSort();
                break;
            case 4:
                Merge mergeSort = new Merge();
                mergeSort.MergeSort();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static int GetUserInput()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter the number of your choice: ");
                int input = int.Parse(Console.ReadLine());
                if (input >= 1 && input <= 4)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}
