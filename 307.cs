public class NumArray {
private int _length;
private int[] _tree;
    public NumArray(int[] nums) {
         _length = nums.Length;
 _tree = new int[4 * _length];
 BuildTree(0, 0, _length - 1, nums);
    }
    
    public void Update(int index, int val)
{
    UpdateTree(0, 0, _length - 1, index, val);
}

public int SumRange(int left, int right)
{
    return QueryTree(0, 0, _length - 1, left, right);
}

private void BuildTree(int index, int left, int right, int[] nums)
{
    if (left == right)
    {
        _tree[index] = nums[left];

        return;
    }

    int middle = left + (right - left) / 2;
    int left_index = 2 * index + 1;
    int right_index = 2 * index + 2;

    BuildTree(left_index, left, middle, nums);
    BuildTree(right_index, middle + 1, right, nums);
    _tree[index] = _tree[left_index] + _tree[right_index];
}

private void UpdateTree(int index, int left, int right, int target, int value)
{
    if (left == right)
    {
        _tree[index] = value;

        return;
    }

    int middle = left + (right - left) / 2;
    int left_index = 2 * index + 1;
    int right_index = 2 * index + 2;

    if (target <= middle)
    {
        UpdateTree(left_index, left, middle, target, value);
    }
    else
    {
        UpdateTree(right_index, middle + 1, right, target, value);
    }

    _tree[index] = _tree[left_index] + _tree[right_index];
}

private int QueryTree(int index, int left, int right, int start, int end)
{
    if (left > end || right < start)
    {
        return 0;
    }

    if (left >= start && right <= end)
    {
        return _tree[index];
    }

    int middle = left + (right - left) / 2;
    int left_index = 2 * index + 1;
    int right_index = 2 * index + 2;
    int left_sum = QueryTree(left_index, left, middle, start, end);
    int right_sum = QueryTree(right_index, middle + 1, right, start, end);

    return (left_sum + right_sum);
}
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */
