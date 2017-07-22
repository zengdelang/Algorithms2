using System;

/// <summary>
/// Binary Indexed Tree(树状数组)
/// </summary>
public class BITree
{
    public int[] m_Data;

    public BITree(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("The num must be greater than 0", "length");
        }
        m_Data = new int[length];
    }

    private int LowBit(int i)
    {
        return i & -i;
    }

    /// <summary>
    /// 数组前n个数的和
    /// </summary>
    public int Sum(int n)
    {
        if (n <= 0 || n > m_Data.Length)
        {
            throw new ArgumentOutOfRangeException("n");
        }

        int sum = 0;
        while (n > 0)
        {
            sum += m_Data[n - 1];
            n -= LowBit(n);
        }
        return sum;
    }

    public void Add(int n, int v)
    {
        if (n <= 0 || n > m_Data.Length)
        {
            throw new ArgumentOutOfRangeException("n");
        }

        var length = Length();
        while (n <= length)
        {
            m_Data[n - 1] += v;
            n += LowBit(n);
        }
    }

    public int Length()
    {
        return m_Data.Length;
    }
}
