using System.Collections.Generic;

/// <summary>
/// 求逆序数
/// </summary>
public class InversionNumber
{
    protected struct NumberNode
    {
        public int value;
        public int order;
    }

    public static int GetInversionNumber(string input)
    {
        List<NumberNode> numberList = new List<NumberNode>(input.Length);
        
        //离散化过程    
        for (int i = 0, length = input.Length; i < length; ++i)
        {
            numberList.Add(new NumberNode()
            {
                value = int.Parse(input[i].ToString()),
                order = i
            });
        }

        numberList.Sort(((node1, node2) =>
        {
            return node1.value.CompareTo(node2.value);
        }));

        int[] values = new int[input.Length];
        for (int i = 0, count = numberList.Count; i < count; ++i)
        {
            values[numberList[i].order] = i + 1;
        }

        //树状数组处理过程
        BITree biTree = new BITree(input.Length);
        int inversionNum = 0;
        for (int i = 0, length = values.Length; i < length; ++i)
        {
            biTree.Add(values[i], 1);
            inversionNum += i + 1 - biTree.Sum(values[i]);
        }

        return inversionNum;
    }
}
