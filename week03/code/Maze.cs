public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap) { _mazeMap = mazeMap; }

    private void Move(int dx, int dy, int index)
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] moves) && moves[index])
        {
            _currX += dx; _currY += dy;
        }
        else throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveLeft() => Move(-1, 0, 0);
    public void MoveRight() => Move(1, 0, 1);
    public void MoveUp() => Move(0, -1, 2);
    public void MoveDown() => Move(0, 1, 3);

    public string GetStatus() => $"Current location (x={_currX}, y={_currY})";
}