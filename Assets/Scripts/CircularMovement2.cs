using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement2 : MonoBehaviour {

    private float RotateSpeed = 1f;
    private float Radius = 2;

    private Vector2 _centre;
    private float _angle;


    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(-Mathf.Sin(_angle), -Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;

    }

}
