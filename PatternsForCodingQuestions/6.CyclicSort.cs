using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsForCodingQuestions
{
    public class CyclicSort
    {
        public CyclicSort() { }

        [Theory]
        [InlineData(new int[] { 3, 1, 5, 4, 2 }, new int[] { 1, 2, 3, 4, 5 })]
        public void Sort(int[] arr, int[] expected)
        {
            int i = 0;
            while (i < arr.Length)
            {
                int j = arr[i] - 1;
                if (arr[i] != arr[j])
                {
                    Swap(arr, i, j);
                }
                else
                {
                    i++;
                }

            }

            Assert.True(expected.SequenceEqual(arr));
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        [Theory]
        [InlineData(new int[] { 4, 0, 3, 1 }, 2)]
        public void FindTheMissingNumber(int[] nums, int expected)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] < nums.Length && nums[i] != nums[nums[i]])
                {
                    Swap(nums, i, nums[i]);
                }
                else
                {
                    i++;
                }
            }

            int actual = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j)
                {
                    actual = j;
                    break;
                }
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 2, 3, 1, 8, 2, 3, 5, 1 }, new int[] { 4, 6, 7 })]
        public void FindTheMissingNumbers(int[] nums, int[] expected)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1])
                {
                    Swap(nums, i, nums[i] - 1);
                }
                else
                {
                    i++;
                }
            }

            List<int> actual = new List<int>();
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j + 1)
                {
                    actual.Add(j + 1);
                }
            }

            Assert.True(expected.SequenceEqual(actual.ToArray()));
        }


        [Theory]
        [InlineData(new int[] { 1, 4, 4, 3, 2 }, 4)]
        public void FindTheDuplicateNumber(int[] nums, int expected)
        {
            int actual = 0;
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != i + 1)
                {
                    if (nums[i] != nums[nums[i] - 1])
                    {
                        Swap(nums, i, nums[i] - 1);
                    }
                    else
                    {
                        actual = nums[i];
                        break;
                    }
                }
                else
                {
                    i++;
                }
            }

            Assert.True(expected.Equals(actual));
        }


        [Theory]
        [InlineData(new int[] { 3, 4, 4, 5, 5 }, new int[] { 4,5 })]
        public void FindTheDuplicateNumbers(int[] nums, int[] expected)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] != nums[nums[i] - 1])
                {
                    Swap(nums, i, nums[i] - 1);
                }
                else
                {
                    i++;
                }
            }

            List<int> actual = new List<int>();
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j + 1)
                    actual.Add(nums[j]);
            }

            Assert.True(expected.SequenceEqual(actual.OrderBy(o => o).ToArray()));
        }
    }
}
