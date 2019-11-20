using System;

namespace MRSTF
{
    class Sort
    {
        public static void SelectionSortReference(int[] arr)
        {
            int N=arr.Length;
            for (int i = 0; i < N - 1; i++)
                for (int j = i + 1; j < N; j++)
                    if (arr[i] > arr[j])
                        Trash.SwapTwoNums(ref arr[i], ref arr[j]);
        }

        public static int[] SelectionSort(int[] arr)
        {
            int pos_min, temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[pos_min]) pos_min = j;
                }

                temp = arr[i];
                arr[i] = arr[pos_min];
                arr[pos_min] = temp;
            }

            return arr;
        }

        public static int[] BubbleSort(int[] arr)
        {
            int tmp = 0;

            for (int i = arr.Length - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }

            return arr;
        }
    }
}