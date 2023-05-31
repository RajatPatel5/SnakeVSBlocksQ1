using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
   
    public float sceneWidth = 10;
    Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        float unitsPerPixel = sceneWidth / Screen.width;
        float desiredHalfHeight = 0.55f * unitsPerPixel * Screen.height;
        _camera.orthographicSize = desiredHalfHeight;
    }

}
