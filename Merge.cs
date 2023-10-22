using System;
using System.Globalization;

public class Merge
{
   
    public void MergeSort()
    {
        int[] initArr = { 4, 6, 3, 8, 2, 1, 10, 7, 5, 9 };
        dispArr("Initial Array", initArr);

        int[] sortedArr = arrCheck(initArr);
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

            int[] arrL = arrCutHalf(arr, 0, half, "Left");
            int[] arrR = arrCutHalf(arr, half, arr.Length, "Right");

            arrL = arrCheck(arrL);
            arrR = arrCheck(arrR);

            return arrMerge(arrL, arrR);
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
    static int[] arrMerge(int[] arrL, int[] arrR){
        Console.WriteLine("---Merge Sort---");
        int[] arrMerge = new int[arrL.Length + arrR.Length];

        int indMerge = 0;
        int indL = 0;
        int indR = 0;

        while(indL < arrL.Length & indR < arrR.Length){
            Console.Write(arrL[indL] + " > " + arrR[indR]);
            if (arrL[indL] > arrR[indR]){
                arrMerge[indMerge] = arrR[indR];
                Console.WriteLine(" : true, insert " + arrR[indR]);
                indR++;
                indMerge++;
            }
            else{
                arrMerge[indMerge] = arrL[indL];
                Console.WriteLine(" : false, insert " + arrL[indL]);
                indL++;
                indMerge++;
            }
        }

        while (indL < arrL.Length){
            arrMerge[indMerge] = arrL[indL];
            Console.WriteLine("insert " + arrL[indL]);
            indL++;
            indMerge++;
        }

        while (indR < arrR.Length){
            arrMerge[indMerge] = arrR[indR];
            Console.WriteLine("insert " + arrR[indR]);
            indR++;
            indMerge++;
        }

        dispArr("arrMerge", arrMerge);
        return arrMerge;
    }
}
