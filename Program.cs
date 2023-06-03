namespace BitonicSort
{
    class Program
    {
        static void Main()
        {
            int[] array = { 3, 7, 4, 8, 6, 2, 1, 5 };
            int dir = 1;   // означает сортировку в порядке возрастания

            Sort bitonicSort = new Sort();
            bitonicSort.DoSort(array, dir);

            Console.Write("Sorted array: \n");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}