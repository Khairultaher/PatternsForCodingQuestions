using Shouldly.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsForCodingQuestions
{
    public class Subsets
    {
        public Subsets()
        {
        }

        [Theory]
        [InlineData(new int[] { 1, 3 })]
        public void FindSubSet(int[] nums)
        {           
            List<List<int>> subsets= new List<List<int>>();
            subsets.Add(new List<int>());

            foreach (var num in nums)
            {
                int n = subsets.Count;
                for (int i = 0; i < n; i++)
                {
                    List<int> subset = new List<int>(subsets[i]);
                    subset.Add(num);
                    subsets.Add(subset);
                }
            }
            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{ },
                new List<int>{ 1},
                new List<int>{ 3},
                new List<int>{ 1, 3}
            }; 
            Assert.True(expected.SequenceEqual(subsets, new ListComparer()));
        }        
        
        [Theory]
        [InlineData(new int[] { 1, 3 })]
        public void SubsetsWithDuplicates(int[] nums)
        {         
            Array.Sort(nums);
            List<List<int>> subsets= new List<List<int>>();
            subsets.Add(new List<int>());

            foreach (var num in nums)
            {
                int n = subsets.Count;
                for (int i = 0; i < n; i++)
                {
                    List<int> subset = new List<int>(subsets[i]);
                    subset.Add(num);
                    subsets.Add(subset);
                }
            }
            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{ },
                new List<int>{ 1},
                new List<int>{ 3},
                new List<int>{ 1, 3}
            }; 
            Assert.True(expected.SequenceEqual(subsets, new ListComparer()));
        }
    }
}
