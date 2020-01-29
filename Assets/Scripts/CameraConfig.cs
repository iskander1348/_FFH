using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfig : MonoBehaviour
{
    public GameObject player;
    public float MaxZoom = 15;
    public float MinZoom = 1;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
       // transform.rotation = player.transform.rotation;
        Camera.main.orthographicSize -= Input.mouseScrollDelta.y/2;
        if (Camera.main.orthographicSize < MinZoom)
                Camera.main.orthographicSize+= 0.5f;
        if (Camera.main.orthographicSize > MaxZoom)
                 Camera.main.orthographicSize-= 0.5f;
    }
}
