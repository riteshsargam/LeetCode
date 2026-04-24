public class Solution {
    public int FurthestDistanceFromOrigin(string moves) {
        int moveLeft = 0;
int moveRight = 0;

foreach (var move in moves)
{
    if (move == 'L')
    {
        moveLeft--;
        moveRight--;
    }
    else if (move == 'R')
    {
        moveRight++;
        moveLeft++;
    }
    else
    {
        moveLeft--;
        moveRight++;
    }

}

return Math.Abs(moveLeft) >= Math.Abs(moveRight) ? Math.Abs(moveLeft) : Math.Abs(moveRight);
    }
}
