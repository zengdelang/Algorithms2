using System;

/// <summary>
/// 二维树状数组
/// </summary>
public class BITree2D
{
    public int[,] m_Data;

    public int Row
    {
        get { return m_Data.GetLength(0); }
    }

    public int Column
    {
        get { return m_Data.GetLength(1); }
    }

    public BITree2D(int row, int column)
    {
        if (row <= 0)
        {
            throw new ArgumentException("The num must be greater than 0", "row");
        }

        if (column <= 0)
        {
            throw new ArgumentException("The num must be greater than 0", "column");
        }

        m_Data = new int[row, column];
    }

    private int LowBit(int i)
    {
        return i & -i;
    }

    /// <summary>
    /// 从1 1 开始到 i j的子矩阵和
    /// </summary>
    public int Sum(int i, int j)
    {
        if (i <= 0 || i > Row)
        {
            throw new ArgumentOutOfRangeException("i");
        }

        if (j <= 0 || j > Column)
        {
            throw new ArgumentOutOfRangeException("j");
        }

        return SumInternal(i, j);
    }

    /// <summary>
    /// 子矩阵和
    /// </summary>
    public int Sum(int top, int left, int bottom, int right)
    {
        if (top <= 0 || top > Row)
        {
            throw new ArgumentOutOfRangeException("top");
        }

        if (left <= 0 || left > Column)
        {
            throw new ArgumentOutOfRangeException("left");
        }

        if (bottom <= 0 || bottom > Row)
        {
            throw new ArgumentOutOfRangeException("bottom");
        }

        if (right <= 0 || right > Column)
        {
            throw new ArgumentOutOfRangeException("right");
        }

        if (top > bottom)
        {
            throw new ArgumentException("The bottom must be greater than top");
        }

        if (left > right)
        {
            throw new ArgumentException("The right must be greater than left");
        }

        //异常处理
        return SumInternal(bottom, right) + SumInternal(top - 1, left - 1) - SumInternal(top - 1, right) - SumInternal(bottom, left - 1);
    }

    private int SumInternal(int i, int j)
    {
        int result = 0;
        for (int x = i; x > 0; x -= LowBit(x))
        {
            for (int y = j; y > 0; y -= LowBit(y))
            {
                result += m_Data[x - 1, y - 1];
            }
        }
        return result;
    }

    public void Add(int i, int j, int value)
    {
        int row = Row;
        int column = Column;

        if (i <= 0 || i > row)
        {
            throw new ArgumentOutOfRangeException("i");
        }

        if (j <= 0 || j > column)
        {
            throw new ArgumentOutOfRangeException("j");
        }

        for (int x = i; x <= row; x += LowBit(x))
        {
            for (int y = j; y <= column; y += LowBit(y))
            {
                m_Data[x - 1,y - 1] += value;
            }
        }
    }
}
