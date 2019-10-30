using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{

    // constructor
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;   
        X = x;
        Y = y;
    }

    // properties
    public Direction Direction { get; set; }

    public int X { get; set; }
        
    public int Y { get; set; }

    // methods
    public void Move(string instructions)
    {
        foreach (char c in instructions)
        {
            switch (c)
            {
                case 'R':
                    MoveRight();
                    break;
                case 'L':
                    MoveLeft();
                    break;
                case 'A':
                    MoveXY();
                    break;
                default:
                    break;
            }
        }
    }

    // turn right by adding 1 from the current enum position. 
    private void MoveRight()
    {
        int newDirection = (int)Direction;
        newDirection++;

        if (newDirection == 4)             // if W and need to move N, change to N
        {
            newDirection = 0;
        }

        Direction = (Direction)newDirection;
    }

    // turn left by subtracting 1 from the current enum position. 
    private void MoveLeft()
    {
        int newDirection = (int)Direction;
        newDirection--;

        if (newDirection == -1)            // if N and need to move W, change to W
        {
            newDirection = 3;
        }

        Direction = (Direction)newDirection;
    }

     private void MoveXY()
    {
        switch (Direction)
        {
            case Direction.North:
                Y++;
                break;
            case Direction.East:
                X++;
                break;
            case Direction.South:
                Y--;
                break;
            case Direction.West:
                X--;
                break;
            default:
                break;
        }
    }
}