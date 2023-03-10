using System.Collections.Generic;

namespace PatternsForCodingQuestions
{
    public class PatternSlidingWindow
    {
        [Theory]
        [InlineData(new int[] { 2,7,5,4}, 9, new int[] { 0,1})]
        public void TwoSumTest(int[] nums, int sum, int[] expected)
        {
            // Arrange
            Dictionary<int, int> keyValues= new Dictionary<int, int>();
            int[] actual = new int[2];

            // Act
            for (int i = 0; i < nums.Length; i++)
            {
                int dif = sum - nums[i];

                if (keyValues.ContainsKey(dif))
                {
                    actual = new int[] { keyValues[dif], i };
                    break;
                }
                else 
                {
                    keyValues.Add(nums[i], i);
                }
            }
            //Assert
            expected.ShouldBe(actual);
        }

    }
}