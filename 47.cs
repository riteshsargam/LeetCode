public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        var numsDictionary = nums
                                .GroupBy(i => i)
                                .ToDictionary(g => g.Key, g => g.Count());
                                
        var uniquePermutations = new List<IList<int>>();

        findUniquePermutations(new List<int>());

        return uniquePermutations;

        void findUniquePermutations(IList<int> currentPermutation) {
            if(currentPermutation.Count == nums.Length) {
                uniquePermutations.Add(new List<int>(currentPermutation));
                return;
            }

            foreach(var numCountPair in numsDictionary) {
                // no more numCountPair.Key left to add
                if (numCountPair.Value == 0) continue;

                currentPermutation.Add(numCountPair.Key);
                numsDictionary[numCountPair.Key]--;

                findUniquePermutations(currentPermutation);

                numsDictionary[numCountPair.Key]++;
                currentPermutation.RemoveAt(currentPermutation.Count - 1);
            }
        }
    }
}
