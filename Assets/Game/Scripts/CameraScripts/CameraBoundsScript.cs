using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsScript : MonoBehaviour
{

    private new Camera camera;
    private Vector3 mapMinBounds;
    private Vector3 mapMaxBounds;

    private GameObject groundPlane;

    // Use this for initialization
    void Start()
    {
       camera = GetComponent<Camera>();
        groundPlane = GameObject.Find("GroundPlane");


        mapMinBounds = groundPlane.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      

    }
}
