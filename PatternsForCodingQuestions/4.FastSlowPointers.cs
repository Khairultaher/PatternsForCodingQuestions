using System.Runtime.Serialization;

namespace PatternsForCodingQuestions;

public class ListNode
{
    public int value = 0;
    public ListNode next;
    public ListNode(int value)
    {
        this.value = value;
    }
}
public class FastSlowPointers
{
    public ListNode head;
    public FastSlowPointers()
    {
        head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);
        head.next.next.next.next.next = new ListNode(6);
    }

    [Fact]
    public void HasCycle()
    {
        // arrange
        bool expected = false;
        // cycle
        head.next.next.next.next.next.next = head.next.next;
        expected = true;
        bool actual = false;

        // act

        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (fast == slow)
            {
                actual = true;
                break;
            }
        }

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FindCycleLength()
    {
        // arrange
        head.next.next.next.next.next.next = head.next.next;
        int expectedCycleLenght = 4;
        int actualCycleLenght = 0;
        // act

        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (fast == slow)
            {
                actualCycleLenght = GetCycleLength(slow);
                break;
            }
        }

        // assert
        Assert.Equal(actualCycleLenght, expectedCycleLenght);
    }

    [Fact]
    public void FindMiddleOfLinkedList()
    {
        // arrange
        head.next.next.next.next.next.next = new ListNode(7);
        int expectedmid = 4;
        int actualmid = 0;

        // act
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        actualmid = slow.value;

        // assert
        Assert.Equal(expectedmid, actualmid);
    }

    [Fact]
    public void StartOfLinkedListCycle()
    {
        // arrange
        head.next.next.next.next.next.next = head.next.next;
        int expected = head.next.next.value;
        int actual = 0;

        // act
        int cycleLenght = 0;
        ListNode slow = head;
        ListNode fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (fast == slow)
            {
                cycleLenght = GetCycleLength(slow);
                break;
            }
        }

        ListNode p1= head;
        ListNode p2= head;

        while (cycleLenght > 0)
        {
            p2 = p2.next;
            cycleLenght--;
        }

        while (p1 != p2)
        {
            p1 = p1.next;
            p2= p2.next;
        }

        actual = p1.value;

        // assert
        Assert.Equal(expected, actual);

    }

    [Theory]
    [InlineData(23, true)]
    public void HappyNumber(int num, bool expected)
    {
        int slow = num;
        int fast = num;

        do
        { 
            slow = FindSquireSum(slow);
            fast = FindSquireSum(FindSquireSum(fast));
        }while(slow != fast);
        bool actual = slow == 1;

        Assert.Equal(expected, actual);
    }

    private int FindSquireSum(int num)
    {
        int sum = 0; int disit = 0;
        while (num > 0)
        {
            disit = num % 10;
            sum += disit * disit;
            num /= 10;
        }

        return sum;
    }

    private int GetCycleLength(ListNode slow)
    {
        int cycleLenght = 0;
        ListNode current = slow;
        do
        {
            current = current.next;
            cycleLenght++;
        } while (current != slow);

        return cycleLenght;
    }
}