using System;
using System.Collections.Generic;

namespace Longest_Consecutive_Sequence_OR_Longest_Busy_Period
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            var nums = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            Console.WriteLine(p.LongestConsecutive(nums));
        }

        /// <summary>
        /// We have taken hashset so that duplicate no we can eliminate and also hashset contains() works in O(1) time.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> hash = new HashSet<int>();
            foreach (int no in nums)
                hash.Add(no); // O(N)

            int longestConsecutive = 0;
            foreach(int current in nums) // O(N)
            {
                int oneLessNo = current - 1;
                if (!hash.Contains(oneLessNo)) // in case the one less no is not present which means the current no is the least no from where the consecutive streak can be started.
                {
                    int nextNo = current + 1;
                    int currentConsecutive = 1;
                    while (hash.Contains(nextNo)) // O(1)
                    {
                        nextNo += 1;
                        currentConsecutive += 1;
                    }

                    longestConsecutive = Math.Max(longestConsecutive, currentConsecutive); // update the longest.
                }
            }

            return longestConsecutive;
        }
    }
}
