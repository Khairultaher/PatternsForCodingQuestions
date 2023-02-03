using System.Collections;

namespace PatternsForCodingQuestions
{
    public class PatternTwoPointers
    {
        [Theory]
        [InlineData(new int[] { -5, 2, -1, -2, 3 })]
        public void TripletSumToZero(int[] arr)
        {
            ArrayList triplests = new ArrayList();

            for (int i = 0; i < arr.Length -2; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1])
                    continue;

                SearchPair(arr, -arr[i], i + 1, triplests);
                    
                
            }
            
            ArrayList expected = new ArrayList
            {
                new int[] { -5, 2, 3},
                new int[] { -1, - 2, 3}
            };

            Assert.Equal(triplests, expected);


            void SearchPair(int[] arr, int targetSum, int left, ArrayList triplests)
            {
                int right = arr.Length - 1;
                while (left < right)
                {
                    int currentSum = arr[left] + arr[right];
                    if (currentSum == targetSum)
                    {
                        triplests.Add(new int[] { -targetSum, arr[left], arr[right] });
                        left++; right--;

                        while (left < right && arr[left] == arr[left - 1])
                        {
                            left++;
                        }

                        while (left < right && arr[right] == arr[right + 1])
                        {
                            right--;
                        }
                    }
                    else if (targetSum > currentSum)
                        left++;

                    else
                        right--;
                }
            }
        }


        [Theory]
        [InlineData(new int[] { -2, 0, 1, 2 }, 2, 1)]
        [InlineData(new int[] { -3, -1, 1, 2 }, 1, 0)]
        public void TripletSumCloseToTarget(int[] arr, int targetSum, int expectedResult)
        {
            if (arr is null || arr.Length < 2)
                Assert.Equal(0, targetSum);

            Array.Sort(arr!);

            int smallestDiff = int.MaxValue;
            int actualResult = int.MaxValue;
            for (int i = 0; i < arr?.Length - 2; i++)
            {
                int left = i + 1; int right = arr.Length - 1;
                bool found = false;
                while (left < right)
                {
                    int targetDiff = targetSum - arr[i] - arr[left] - arr[right];

                    if (targetDiff == 0)
                    {
                        actualResult = targetSum - targetDiff;
                        found = true;
                        break;
                    }

                    if (Math.Abs(targetDiff) < Math.Abs(smallestDiff))
                    {
                        smallestDiff = targetDiff;
                    }

                    if (targetDiff > 0)
                        left++;
                    else
                        right--;
                }

                if (found)
                    break;
            }

            if (actualResult == int.MaxValue)
                actualResult = targetSum - smallestDiff;

            Assert.Equal(actualResult, expectedResult);
        }

    }
}