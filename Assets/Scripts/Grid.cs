using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour{

    public LayerMask obstructionMask;
    public Vector2 gridSize;
    public float nodeRadius;
    Node[,] grid;
    

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridSize.y / nodeDiameter);
        CreateGrid();
    }

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector2 gridBottomLeft = new Vector2(transform.position.x,transform.position.y) - Vector2.right * gridSize.x / 2 - Vector2.up * gridSize.y / 2;

        for(int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 gridPoint = gridBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(gridPoint, nodeRadius, obstructionMask));
                grid[x, y] = new Node(walkable, gridPoint, x, y);
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> Neighbour = new List<Node>();

        for(int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if(checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    Neighbour.Add(grid[checkX, checkY]);
                }
            }
        }

        return Neighbour;
    }

    public Node NodeFromGridPoint(Vector2 worldPos)
    {
        float percentX = (worldPos.x + gridSize.x / 2) / gridSize.x;
        float percentY = (worldPos.y + gridSize.y / 2) / gridSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

   
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(gridSize.x, gridSize.y));
        
        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.obstruction) ? Color.white : Color.red;   
                Gizmos.DrawCube(n.worldPosition, Vector2.one * (nodeDiameter - .1f));
  
            }
        }
    }

}
