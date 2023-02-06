using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatternsForCodingQuestions
{
    public class TreeDepthFirstSearch
    {
        public TreeDepthFirstSearch() { }

        [Fact]
        public void BinaryTreePathSum()
        {
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            //root.left.right = new TreeNode(10);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);

            bool expected = true;

            bool HasPath(TreeNode root, int sum)
            {
                if (root == null)
                    return false;

                if (root.val == sum && root.right == null && root.left == null)
                    return true;

                return HasPath(root.left, sum - root.val) || HasPath(root.right, sum - root.val);
            }

            bool actual = HasPath(root, 23);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void AllPathsForSum()
        {
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(4);
            //root.left.right = new TreeNode(10);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);

            List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 12, 7, 4},
                new List<int> { 12, 1, 10},
            };

            List<List<int>> actual = new List<List<int>>();

            void FindPathRecursive(TreeNode node, int targetSum, 
                List<int> currentPath, List<List<int>> allPaths)
            {
                if (node == null) return;
                currentPath.Add(node.val);
                if (node.val == targetSum && node.left == null && node.right == null)
                {
                    allPaths.Add(new List<int>(currentPath));
                }
                else
                {
                    FindPathRecursive(node.left, targetSum - node.val, currentPath, allPaths);
                    FindPathRecursive(node.right, targetSum - node.val, currentPath, allPaths);
                }
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            List<IList<int>> result = new List<IList<int>>();
            List<int> currentPath = new List<int>();
            FindPathRecursive(root, 23, currentPath, actual);

            Assert.True(expected.SequenceEqual(actual, new ListComparer()));
        }
    }
}
