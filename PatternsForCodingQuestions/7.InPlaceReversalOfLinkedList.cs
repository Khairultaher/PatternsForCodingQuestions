namespace PatternsForCodingQuestions
{
    public class InPlaceReversalOfLinkedList
    {
        ListNode head;
        public InPlaceReversalOfLinkedList()
        {
            head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
        }

        [Theory]
        [InlineData(new int[] { 6, 5, 4, 3, 2, 1 })]
        public void ReverseLinkedList(int[] expected)
        {
            ListNode current = head;
            ListNode prev = null;
            ListNode next = null;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            List<int> actual = new List<int>();
            ListNode res = prev;
            while (res != null)
            {
                actual.Add(res.value);
                res = res.next;
            }

            Assert.True(expected.SequenceEqual(actual.ToArray()));
        }


        [Theory]
        [InlineData(2, 4, new int[] { 1, 4, 3, 2, 5 })]
        public void ReverseSubList(int p, int q, int[] expected)
        {
            // arrange
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = new ListNode(7);
            head.next.next.next.next.next.next.next = new ListNode(8);

            // act
            ListNode res = ReverseSub(head, p, q);

            List<int> actual = new List<int>();
            while (res != null)
            {
                actual.Add(res.value);
                res = res.next;
            }

            // assert
            Assert.True(expected.SequenceEqual(actual.ToArray()));
        }

        [Theory]
        public void ReverseEveryKelementSubList()
        {

        }

        private ListNode ReverseSub(ListNode head, int p, int q)
        {
            if (p == q)
                return head;

            ListNode curr = head;
            ListNode prev = null;

            for (int i = 0; curr != null && i < p - 1; ++i)
            {
                prev = curr;
                curr = curr.next;
            }


            ListNode lastNodeOfFirstPart = prev;
            ListNode lastNodeOfSubPart = curr;

            ListNode next = null;
            for (int i = 0; i < q - p + 1; i++)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            if (lastNodeOfFirstPart != null)
            {
                lastNodeOfFirstPart.next = prev;
            }
            else
            {
                head = prev;
            }

            lastNodeOfSubPart.next = curr;

            return head;
        }
    }
}
