using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PatternsForCodingQuestions
{
    public class ModifiedBinarySearch
    {
        public ModifiedBinarySearch() { }


        [Theory]
        [InlineData(new int[] { 4, 6, 10 }, 10, 2)]
        [InlineData(new int[] { 10, 6, 4 }, 10, 0)]
        public void OrderAgnosticBinarySearch(int[] nums, int target, int expected)
        {
            int start = 0, end = nums.Length -1;
            bool asscending = nums[start] < nums[end];

            int actual = -1;
            while (start <= end)
            {
                int middle = start + (end - start) / 2;

                if (nums[middle] == target)
                {
                    actual = middle;
                    break;
                }

                if (asscending)
                {
                    if (target < nums[middle])
                    {
                        end = middle - 1;
                    }
                    else 
                    {
                        start = middle + 1;
                    }
                }
                else 
                {
                    if (target < nums[middle])
                    {
                        start = middle + 1;
                    }
                    else
                    {
                        end = middle - 1;
                    }
                }
            }

            Assert.Equal(expected, actual);

        }
    }
}
