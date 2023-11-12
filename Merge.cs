using System;
using System.Globalization;

public class Merge
{
   
    public void MergeSort()
    {
        int[] numArr = { 4, 6, 3, 8, 2, 1, 10, 7, 5, 9 };
        dispArr("Initial Array", numArr);

        int[] sortedArr = arrCheck(numArr);
        dispArr("Sorted Array", sortedArr);

        Console.WriteLine("");
        Console.ReadLine();
    
    }

    // Displaying array
    static void dispArr(String txt, int[] arr){
        Console.Write(txt + ": ");
        for (int i = 0; i < arr.Length; i++){
            Console.Write(arr[i] + ", ");
        }
        Console.WriteLine("\n");
    }

    // Array Check
    static int[] arrCheck(int[] arr){
        if (arr.Length > 1){
            int half = arr.Length / 2;

            int[] leftSide = arrCutHalf(arr, 0, half, "Left");
            int[] rightSide = arrCutHalf(arr, half, arr.Length, "Right");

            leftSide = arrCheck(leftSide);
            rightSide = arrCheck(rightSide);

            return arrMerge(leftSide, rightSide);
        }
        else{
            return arr;
        }
    }

    // Array Gets Cut in Half
    static int[] arrCutHalf(int[] oldArr, int from, int to, String arrSide){
        Console.WriteLine("---Cut Half---");
        int[] newArr = new int[to-from];
        Console.WriteLine("new size["+arrSide+"]:" + newArr.Length);

        int ctr = 0;
        for (int i = from; i < to; i++){
            newArr[ctr] = oldArr[i];
            ctr++;
        }
        dispArr("newArr[" + arrSide + "]", newArr);
        return newArr;
    }

    // Merge all arrays
    static int[] arrMerge(int[] leftSide, int[] rightSide){
        Console.WriteLine("---Merge Sort---");
        int[] arrMerge = new int[leftSide.Length + rightSide.Length];

        int indexM = 0;
        int indexL = 0;
        int indexR = 0;

        while(indexL < leftSide.Length & indexR < rightSide.Length){
            Console.Write(leftSide[indexL] + " > " + rightSide[indexR]);
            if (leftSide[indexL] > rightSide[indexR]){
                arrMerge[indexM] = rightSide[indexR];
                Console.WriteLine(" : true, insert " + rightSide[indexR]);
                indexR++;
                indexM++;
            }
            else{
                arrMerge[indexM] = leftSide[indexL];
                Console.WriteLine(" : false, insert " + leftSide[indexL]);
                indexL++;
                indexM++;
            }
        }

        while (indexL < leftSide.Length){
            arrMerge[indexM] = leftSide[indexL];
            Console.WriteLine("insert " + leftSide[indexL]);
            indexL++;
            indexM++;
        }

        while (indexR < rightSide.Length){
            arrMerge[indexM] = rightSide[indexR];
            Console.WriteLine("insert " + rightSide[indexR]);
            indexR++;
            indexM++;
        }

        dispArr("arrMerge", arrMerge);
        return arrMerge;
    }
}
