using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crackedWall : MonoBehaviour {

    // Use this for initialization
    public void destroyWall()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
