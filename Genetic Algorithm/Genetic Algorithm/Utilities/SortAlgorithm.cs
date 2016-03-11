using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class SortAlgorithm
    {

        /// <summary>
        /// Mergesort 2 lists.
        /// </summary>
        /// <param name="entitys">The entity list to sort.</param>
        /// <param name="left">The left index.</param>
        /// <param name="mid">The middle index.</param>
        /// <param name="right">The right index.</param>
        public static void DoMerge(AIEntity[] entitys, int left, int mid, int right)
        {
            AIEntity[] temp = new AIEntity[entitys.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (entitys[left].GetFittingValue() >= entitys[mid].GetFittingValue())
                    temp[tmp_pos++] = entitys[left++];
                else
                    temp[tmp_pos++] = entitys[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = entitys[left++];

            while (mid <= right)
                temp[tmp_pos++] = entitys[mid++];

            for (i = 0; i < num_elements; i++)
            {
                entitys[right] = temp[right];
                right--;
            }
        }

        /// <summary>
        /// Mergesort entitys by fitnessvalue.
        /// </summary>
        /// <param name="entitys">The entitys array to sort.</param>
        /// <param name="left">The left index.</param>
        /// <param name="right">The right index.</param>
        static public void MergeSort(AIEntity[] entitys, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(entitys, left, mid);
                MergeSort(entitys, (mid + 1), right);

                DoMerge(entitys, left, (mid + 1), right);
            }
        }
    }
}
