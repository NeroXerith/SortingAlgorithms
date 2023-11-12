using System;
using System.Globalization;

public class Heap
{
    static int lastInd;
    static void HeapSort()
    {
        // User input up to 5 digits (dunno)
        Console.Write("ENTER HOW MANY ITEMS: ");
        int totalNum = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[totalNum];
        lastInd = arr.Length;

        for (int i = 0; i < arr.Length; i++){
            Console.Write("[" + i + "]: ");

            if (int.TryParse(Console.ReadLine(), out arr[i]))
                Console.WriteLine("--- ADDED ---");
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                i--;
            }
        }

        dispArr("Orig", arr);
        
        int choiceNum;

        // Checks if input is either 0 or 1 now
        while (true){
            // Lets user choose if [0] ASCENDING or [1] DESCENDING
            Console.WriteLine("[0] ASCENDING | [1] DESCENDING");
            Console.Write("Choice: ");

            if (int.TryParse(Console.ReadLine(), out choiceNum)){
                switch(choiceNum){
                    case 0:
                        Console.WriteLine("You chose ASCENDING");
                        for (int i = 0; i < arr.Length; i++){
                            Console.WriteLine("---");
                            
                            // For max heap
                            arr = maxHeap(arr);
                            dispArr("Max Heap[" + (i + 1) + "]", arr);

                            // Heapify
                            arr = heapify(arr);
                            dispArr("Heapify[" + (i + 1) + "]", arr);
                        }
                        break;
                    case 1:
                        Console.WriteLine("You chose DESCENDING");
                        for (int i = 0; i < arr.Length; i++){
                            Console.WriteLine("---");

                            // For min heap
                            arr = minHeap(arr);
                            dispArr("Min Heap[" + (i + 1) + "]", arr);

                            // Heapify
                            arr = heapify(arr);
                            dispArr("Heapify[" + (i + 1) + "]", arr);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. 0 or 1 only.");
                        break;
                }
                
                if (choiceNum == 0 || choiceNum == 1){
                    break;
                }
            }
            else{
                Console.WriteLine("Invalid choice. 0 or 1 only.");
            }
        }
    }

    // -- [1] Heap Sort --

    // Min Heap
    static int[] minHeap(int[] arr){
        for (int i = lastInd; i > 1; i--)
        {
            int parent = i / 2;
            int LChild = 2 * parent;
            int RChild = 2 * parent + 1;
            parent--;
            LChild--;
            RChild--;

            bool hasRChild = false;
            if (parent < lastInd)
            {
                // Console.WriteLine("P:" + arr[parent]);
            }
            if (LChild < lastInd)
            {
                // Console.WriteLine("LC:" + arr[LChild]);
            }
            if (RChild < lastInd)
            {
                // Console.WriteLine("RC:" + arr[RChild]);
                hasRChild = true;
            }
            if (hasRChild)
            {
                if (arr[parent] > arr[RChild] && arr[RChild] < arr[LChild])
                {
                    int temp = arr[parent];
                    arr[parent] = arr[RChild];
                    arr[RChild] = temp;
                }
            }
            if (arr[parent] > arr[LChild])
            {
                int temp = arr[parent];
                arr[parent] = arr[LChild];
                arr[LChild] = temp;
            }
        }

        return arr;
    }

    // Max Heap
    static int[] maxHeap(int[] arr){
        for (int i = lastInd; i > 1; i--){
            // Console.WriteLine("checking arr[" + i + "]:" + arr[i-1]);
            int parent = (i / 2);
            int LChild = (2 * parent);
            int RChild = (2 * parent + 1);
            parent--;
            LChild--;
            RChild--;

            // Boolean hasLChild = false;
            Boolean hasRChild = false;
            if (parent < lastInd){
                // Console.WriteLine("P:" + arr[parent]);
            }
            if (LChild < lastInd){
                // Console.WriteLine("LC:" + arr[LChild]);
                // hasLChild = true;
            }
            if (RChild < lastInd){
                // Console.WriteLine("RC:" + arr[RChild]);
                hasRChild = true;
            }
            if (hasRChild){
                if (arr[parent] < arr[RChild] & arr[RChild] > arr[LChild]){
                    int temp = arr[parent];
                    arr[parent] = arr[RChild];
                    arr[RChild] = temp;
                }
            }
            if (arr[parent] < arr[LChild]){
                int temp = arr[parent];
                arr[parent] = arr[LChild];
                arr[LChild] = temp;
            }

            // Console.WriteLine("-----");
        }

        return arr;
    }

    // Heapify
    static int[] heapify(int[] arr){
        int temp = arr[0];
        arr[0] = arr[lastInd - 1];
        arr[lastInd - 1] = temp;

        lastInd--;

        return arr;
    }
    
    // Displaying array
    static void dispArr(String txt, int[] arr){
        Console.Write(txt + ": ");
        for (int i = 0; i < arr.Length; i++){
            Console.Write(arr[i] + ", ");
        }
        Console.Write("\n");
    }
}
