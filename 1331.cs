public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        int length = arr.Length;
        if (length == 0)
        {
            return [];
        }
        else if (length == 1)
        {
            return [1];
        }

        (int Index, int Element, int Rank)[] temp = new (int, int, int)[length];
        for (int i = 0; i < length; i++)
        {
            temp[i] = (i, arr[i], 1);
        }

        Array.Sort(temp, (a, b) => a.Element.CompareTo(b.Element));
        for (int i = 1; i < length; i++)
        {
            temp[i].Rank = temp[i - 1].Rank;
            if (temp[i].Element != temp[i - 1].Element)
            {
                temp[i].Rank++;
            }
        }

        Array.Sort(temp, (a, b) => a.Index.CompareTo(b.Index));

        return (from element in temp select element.Rank).ToArray();
    }
}
