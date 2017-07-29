public class TestList
{
    public int Value;
    public TestList Next;
}

public class CycleDetection
{
    /// <summary>
    /// 检测链表是否有环，有则返回环的开头，否则为null
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static TestList DetectCycle(TestList list)
    {
        var fast = list;
        var slow = fast;
        bool isCircular = true;

        do
        {
            if (fast.Next == null || fast.Next.Next == null)
            {
                isCircular = false;
                break;
            }

            slow = slow.Next;
            fast = fast.Next.Next;

        } while (fast != slow);

        if (!isCircular)
            return null;

        slow = list;
        while (slow != fast)
        {
            slow = slow.Next;
            fast = fast.Next;
        }

        return slow;
    }
}

