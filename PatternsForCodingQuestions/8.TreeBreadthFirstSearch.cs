using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PatternsForCodingQuestions
{
    class ListComparer : EqualityComparer<List<int>>
    {
        public override bool Equals(List<int> x, List<int> y)
        {
            return x.SequenceEqual(y);
        }

        public override int GetHashCode(List<int> obj)
        {
            return obj.GetHashCode();
        }
    }
    public class TreeNode
    {
        public int val = 0;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val) {
            this.val = val;
        }
    }
    public class TreeBreadthFirstSearch
    {
        public TreeBreadthFirstSearch() { }

        [Fact]
        public void BinaryTreeLevelOrderTraversal()
        {
            // arrange
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            //root.left.right = new TreeNode(10);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);

            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>{ 12},
                new List<int>{ 7, 1},
                new List<int>{ 9 ,10, 5}
            };

            // act
            List<List<int>> actual = Traverse(root);

            // assert
            Assert.True(expected.SequenceEqual(actual, new ListComparer()));
        }

        [Fact]
        public void ReverseLevelOrderTraversal()
        {
            // arrange
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            //root.left.right = new TreeNode(10);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);

            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>{ 9 ,10, 5},
                new List<int>{ 7, 1},
                new List<int>{ 12},
            };

            // act
            Func<TreeNode, List<List<int>>> Traverse = (root) =>
            {
                List<List<int>> result = new List<List<int>>();
                if (root == null)
                    return result;

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    int levelSize = queue.Count;
                    List<int> currentLevel = new List<int>();
                    for (int i = 0; i < levelSize; i++)
                    {
                        TreeNode curentNode = queue.Dequeue();
                        currentLevel.Add(curentNode.val);
                        if (curentNode.left != null)
                        {
                            queue.Enqueue(curentNode.left);
                        }
                        if (curentNode.right != null)
                        {
                            queue.Enqueue(curentNode.right);
                        }
                    }

                    result.Insert(0, currentLevel);
                }
                return result;
            };

            List<List<int>> actual = Traverse(root);
            // assert
            Assert.True(expected.SequenceEqual(actual, new ListComparer()));
        }
        private List<List<int>> Traverse(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            if(root == null)
                return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0) 
            {
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>();
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode curentNode = queue.Dequeue();
                    currentLevel.Add(curentNode.val);
                    if (curentNode.left != null)
                    {
                        queue.Enqueue(curentNode.left);
                    }
                    if (curentNode.right != null)
                    {
                        queue.Enqueue(curentNode.right);
                    }
                }

                result.Add(currentLevel);
            }
            
            return result;
        }

        [Fact]
        public void ZigzagTraversal()
        {
            // arrange
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            //root.left.right = new TreeNode(10);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);

            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>{ 12},
                new List<int>{ 1, 7},
                new List<int>{ 9 ,10, 5}
            };

            Func<TreeNode, List<List<int>>> Traverse = (root) =>
            {
                List<List<int>> result = new List<List<int>>();
                if (root == null)
                    return result;

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                bool leftToRight = true;
                while (queue.Count > 0)
                {
                    int levelSize = queue.Count;
                    List<int> currentLevel = new List<int>();
                    for (int i = 0; i < levelSize; i++)
                    {
                        TreeNode curentNode = queue.Dequeue();
                        if(leftToRight)
                            currentLevel.Add(curentNode.val);
                        else
                            currentLevel.Insert(0, curentNode.val);

                        if (curentNode.left != null)
                        {
                            queue.Enqueue(curentNode.left);
                        }
                        if (curentNode.right != null)
                        {
                            queue.Enqueue(curentNode.right);
                        }
                    }

                    result.Add(currentLevel);
                    leftToRight = !leftToRight;
                }
                return result;
            };
            // act
            List<List<int>> actual = Traverse(root);

            // assert
            Assert.True(expected.SequenceEqual(actual, new ListComparer()));
        }
    }
}
