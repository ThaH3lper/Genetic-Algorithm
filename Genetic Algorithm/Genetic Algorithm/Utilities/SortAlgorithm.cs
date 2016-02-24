using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Algorithm
{
    class SortAlgorithm
    {
        public static void DoMerge(AIEntity[] entitys, int left, int mid, int right)
        {
            AIEntity[] temp = new AIEntity[entitys.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (entitys[left].GetFittingLevel() >= entitys[mid].GetFittingLevel())
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
