using UnityEngine;
public class Cell
{
    public Vector2Int cords;
    public CellType type;

    public Cell(Vector2Int cords)
    {
        this.cords = cords;
    }
}

public enum CellType
{
    Walkable,
    Wall,
}