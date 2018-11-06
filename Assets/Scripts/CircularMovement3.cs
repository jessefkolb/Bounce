using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement3 : MonoBehaviour {

    private float RotateSpeed = 1f;
    private float Radius = 2f;

    private Vector2 _centre;
    private float _angle;


    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {

        if (this.gameObject.CompareTag("wheel1")) Radius = (float)1.5f;
        if (this.gameObject.CompareTag("wheel2")) Radius = (float)1f;
        if (this.gameObject.CompareTag("wheel3")) Radius = (float).5f;

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Cos(_angle), -Mathf.Sin(_angle)) * Radius;
        transform.position = _centre + offset;

    }

}
