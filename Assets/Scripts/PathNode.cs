public class PathNode
{
    public int gCost;
    public int hCost;
    public int fCost;

    public PathNode cameFromNode;

    MyGrid<PathNode> grid;
    public int x;
    public int z;

    public PathNode(MyGrid<PathNode> grid, int x, int z)
    {
        this.grid = grid;
        this.x = x;
        this.z = z;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        return $"{x},{z}";
    }
}
