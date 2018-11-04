using System.Collections;
using UnityEngine;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class Enemy_Flying_AI: MonoBehaviour {

    public Transform target; //what ai is seeking
    public float updateDelay = 2f; //update path rate

    private Seeker seeker;
    private Rigidbody2D rb2d;
    public Path path; 
    public float speed = 100f;
    public ForceMode2D fMode;
    public float continueDist = 3; //how far to waypoint to look for next waypoint
    private int currPoint = 0; //target point
    public bool pathEnd = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();

        if(target == null)
        {
            Debug.LogError("Target not set");
        }

        seeker.StartPath(transform.position, target.position, OnPathDelegate);

        StartCoroutine(UpdatePath());


       
    }

    IEnumerator UpdatePath()
    {
        seeker.StartPath(transform.position, target.position, OnPathDelegate);
        yield return new WaitForSeconds(1f / updateDelay);
        StartCoroutine(UpdatePath());
    }

    public void OnPathDelegate(Path p)
    {
        Debug.Log("Path" + p.error);
        if (!p.error)
        {
            path = p;
            currPoint = 0;
        }
    }

    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }

        if(currPoint >= path.vectorPath.Count)
        {
            if(pathEnd) return;

            pathEnd = true;
            return;
        }

        pathEnd = false;

        //get direction
        Vector3 dir = (path.vectorPath[currPoint] - transform.position).normalized;
        dir = dir * speed * Time.fixedDeltaTime;

        //move
        rb2d.AddForce(dir, fMode);

        float distance = Vector3.Distance(transform.position, path.vectorPath[currPoint]);

        if(distance < continueDist)
        {
            currPoint++;
            return;
        }

    }

}
