public static class MathLibs
{
    /// <summary>
    /// Computing the greatest common divisor with Stein's algorithm.
    /// </summary>
    public static int Gcd(int a, int b)
    {
        //gcd(a, a) = a
        if (a == b)
            return a;

        // gcd(a,0) == a
        if (a == 0)
            return b;

        //gcd(0, b) == b
        if (b == 0)
            return a;

        //Finding K, where K is the greatest power of 2
        //that divides both a and b. 
        int k;
        for (k = 0; ((a | b) & 1) == 0; ++k)
        {
            a >>= 1;
            b >>= 1;
        }

        // Dividing a by 2 until a becomes odd 
        while ((a & 1) == 0)
            a >>= 1;

        // From here on, 'a' is always odd.
        do
        {
            // If b is even, remove all factor of 2 in b 
            while ((b & 1) == 0)
                b >>= 1;
            
            // Now a and b are both odd. Swap if necessary
            // so a <= b, then set b = b - a (which is even).
            if (a > b)
            {
                a ^= b;
                b ^= a;
                a ^= b;
            }
            b = (b - a);
        } while (b != 0);

        // restore common factors of 2
        return a << k;
    }

    /// <summary>
    /// Computing the lowest common multiple
    /// a * b = gcd(a, b) * lcm(a, b)
    /// </summary>
    public static int Lcm(int a, int b)
    {
        int c = a * b;
        if (c == 0)
            return c;
        return c / Gcd(a, b);
    }
}
