namespace MoveRobot;

public class RobotMovement
{
    public Direction Direction { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public RobotMovement (Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    private void TurnRight() =>
        Direction = (Direction)(((int)Direction + 1) % 4);

    private void TurnLeft() =>
        Direction = (Direction)(((int)Direction + 3) % 4);

    private void Advance() =>
        (X, Y) = Direction switch
        {
            Direction.North => (X, Y + 1),
            Direction.East => (X + 1, Y),
            Direction.South => (X, Y - 1),
            Direction.West => (X - 1, Y),
            _ => throw new ArgumentException()
        };

    public void Move(string instructions)
    {
        foreach (var step in instructions)
        {
            switch (step)
            {
                case 'A': Advance(); break;
                case 'R': TurnRight(); break;
                case 'L': TurnLeft(); break;
            }
        }
    }
}