using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitonicSort
{
    public class Sort
    {
        // Чтобы поменять значения
        private void Swap<T>(ref T element1, ref T element2)
        {
            (element1, element2) = (element2, element1);
        }

        private void CompAndSwap(int[] array, int i, int j, int dir)
        {
            int k;
            if ((array[i] > array[j]))
            {
                k = 1;
            }
            else
            {
                k = 0;
            }
            if (dir == k)
            {
                Swap(ref array[i], ref array[j]);
            }
        }

        /// <summary>
        /// Рекурсивно сортирует битоническую последовательность в порядке возрастания,
        /// если dir = 1, и в порядке убывания в противном случае (означает dir = 0).
        /// Последовательность для сортировки начинается с позиции индекса низкого уровня,
        /// параметр cnt - это количество элементов для сортировки
        /// </summary>
        /// <param name="a"></param>
        /// <param name="low"></param>
        /// <param name="cnt"></param>
        /// <param name="dir"></param>
        private void MergeSequenceAndSort(int[] array, int low, int dir)
        {
            int cnt = array.Length;
            if (cnt > 1)
            {
                int k = cnt / 2; // делим пополам, так как будем сравнивать элементы из 2-х частей массива

                // помните мы сравнивали элементы и раскидывали по массивам? вот делаем это только меняем местами
                for (int i = low; i < low + k; i++)
                {
                    CompAndSwap(array, i, i + k, dir);
                }
                
                MergeSequenceAndSort(array, low, dir); // и снова рекурсия
                MergeSequenceAndSort(array, low + k, dir);
            }

        }

        /// <summary>
        /// Эта функция сначала создает битонную последовательность рекурсивно
        /// сортирует ее две половинки в противоположных порядках сортировки, 
        /// а затем вызывает bitonicMerge, чтобы сделать их в том же порядке
        /// </summary>
        /// <param name="a"></param>
        /// <param name="low"></param>
        /// <param name="cnt"></param>
        /// <param name="dir"></param>
        private void BitonicSortMethod(int[] array, int low, int dir)
        {
            int cnt = array.Length;
            if (cnt > 1)
            {
                int k = cnt / 2; // делим пополам последовательность

                // сортируем первую часть по возрастанию
                BitonicSortMethod(array, low, 1);

                // сортирует вторую по убыванию
                BitonicSortMethod(array, low + k, 0);

                // объединяем последовательности и сортируем
                MergeSequenceAndSort(array, low, dir);

            }
        }

        /// <summary>
        /// Вызывающая сторона bitonicSort для сортировки всего массива в порядке возрастания
        /// </summary>
        /// <param name="a"></param>
        /// <param name="N"></param>
        /// <param name="up"></param>
        public void DoSort(int[] array, int dir)
        {
            BitonicSortMethod(array, 0, dir);
        }
    }
}
