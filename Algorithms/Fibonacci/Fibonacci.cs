using System;

public struct MatrixFibonacci
{
    private long m_v11;
    private long m_v12;
    private long m_v21;
    private long m_v22;

    public MatrixFibonacci(long v11, long v12, long v21, long v22)
    {
        m_v11 = v11;
        m_v12 = v12;
        m_v21 = v21;
        m_v22 = v22;
    }

    public void Multiply(MatrixFibonacci matrix)
    {
        var v11 = m_v11*matrix.m_v11 + m_v12*matrix.m_v21;
        var v12 = m_v11*matrix.m_v12 + m_v12*matrix.m_v22;
        var v21 = m_v21*matrix.m_v11 + m_v22*matrix.m_v21;
        var v22 = m_v21*matrix.m_v12 + m_v22*matrix.m_v22;

        m_v11 = v11;
        m_v12 = v12;
        m_v21 = v21;
        m_v22 = v22;
    }

    public long this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return m_v11;
                case 1:
                    return m_v12;
                case 2:
                    return m_v21;
                case 3:
                    return m_v22;
            }
            throw new IndexOutOfRangeException();
        }
    }
}

public class Fibonacci
{
    private readonly int m_FirstNumber;
    private readonly int m_SecondNumber;

    public Fibonacci(int first = 0, int second = 1)
    {
        m_FirstNumber  = first;
        m_SecondNumber = second;        
    }

    public long GetFabonacciNumber(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException("n");
        }

        if(n == 1)
            return m_FirstNumber;

        if(n == 2)
            return m_SecondNumber;

        n -= 2;

        MatrixFibonacci result = new MatrixFibonacci(1, 0, 0, 1);
        MatrixFibonacci temp = new MatrixFibonacci(1, 1, 1, 0);
        while (n != 0)
        {
            if((n & 1) == 1)
                result.Multiply(temp);

            temp.Multiply(temp);
            n >>= 1;
        }

        return result[0] * m_SecondNumber + result[1] * m_FirstNumber;
    }
}
