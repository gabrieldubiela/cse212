/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE

        // Check is is exist the position and if is avaliable the left position
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][0] == true)
        {
            //  Go left change the X by -1
            _currX--;
        }
        else
            // Return the phrase "Can't go that way!"
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
        {
        // FILL IN CODE

        // Check is is exist the position and if is avaliable the right position
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][1] == true)
        {
            //  Go right change the X by +1
            _currX++;
        }
        else
            // Return the phrase "Can't go that way!"
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE

        // Check is is exist the position and if is avaliable the up position
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][2] == true)
        {
            //  Go up change the Y by -1
            _currY--;
        }
        else
            // Return the phrase "Can't go that way!"
            throw new InvalidOperationException("Can't go that way!");
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE

        // Check is is exist the position and if is avaliable the down position
        if (_mazeMap.ContainsKey((_currX, _currY)) && _mazeMap[(_currX, _currY)][3] == true)
        {
            //  Go up change the Y by +1
            _currY++;
        }
        else
            // Return the phrase "Can't go that way!"
            throw new InvalidOperationException("Can't go that way!"); 
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}