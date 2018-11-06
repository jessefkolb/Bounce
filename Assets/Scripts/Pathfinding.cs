using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pathfinding : MonoBehaviour {

    Grid grid;
    PathRequestManager requestManager;
 

    void Awake()
    {
        grid = GetComponent<Grid>();
        requestManager = GetComponent<PathRequestManager>();
    }

  

    public void StartFindPath(Vector2 startPos, Vector2 targetPos)
    {
        StartCoroutine(FindPath(startPos, targetPos));
    }


    IEnumerator FindPath(Vector2 start, Vector2 target)
    {
        Vector2[] waypoints = new Vector2[0];
        bool pathSuccess = false;

        Node startNode = grid.NodeFromGridPoint(start);
        Node targetNode = grid.NodeFromGridPoint(target);

        if (startNode.obstruction && targetNode.obstruction)
        {

            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closeSet = new HashSet<Node>();

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currNode = openSet.RemoveFirst();
                closeSet.Add(currNode);

                if (currNode == targetNode)
                {
                    pathSuccess = true;

                    yield return null;
                }

                foreach (Node neighbour in grid.GetNeighbours(currNode))
                {
                    if (!neighbour.obstruction || closeSet.Contains(neighbour)) continue;

                    int newMovementCost = currNode.gCost + GetDistance(currNode, neighbour);

                    if (newMovementCost < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementCost;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currNode;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);

                        }
                    }
                }


            }
        }
        yield return null;
        if (pathSuccess)
        {
            waypoints = TracePath(startNode, targetNode);
        }
        requestManager.FinishedProcessingPath(waypoints, pathSuccess);
    }
    
    Vector2[] TracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currNode = endNode;

        while(currNode != startNode)
        {
            path.Add(currNode);
            currNode = currNode.parent;
        }
        Vector2[] waypoints = SimplifyPath(path);
        Array.Reverse(waypoints);
        return waypoints;
    }

    Vector2[] SimplifyPath(List<Node> path)
    {
        List<Vector2> waypoints = new List<Vector2>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if (directionNew != directionOld)
            {
                waypoints.Add(path[i].worldPosition);
            }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if(distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }

        return 14 * distX + 10 * (distY - distX);
    }
}
