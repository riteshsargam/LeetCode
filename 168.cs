public class Solution {
    public string ConvertToTitle(int columnNumber) {
        if (columnNumber == 0) return "";
        columnNumber--;
        char c = (char) ('A' + columnNumber % 26);
        return ConvertToTitle(columnNumber / 26) + c;
    }
}
