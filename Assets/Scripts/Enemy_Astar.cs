using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Astar : MonoBehaviour {

    public Transform target;
    float speed = 20;
    Vector2[] path;
    int targetIndex;

    void Start()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 tarPos = new Vector2(target.position.x, target.position.y);
        PathRequestManager.RequestPath(pos, tarPos, OnPathFound);
    }

    public void OnPathFound(Vector2[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector2 currentWaypoint = path[0];
        while (true)
        {
            Vector2 currPos = new Vector2(transform.position.x, transform.position.y);
            if (currPos == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            currPos = Vector2.MoveTowards(currPos, currentWaypoint, speed * Time.deltaTime);
            yield return null;

        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}
