using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{
    public static float PixelsToUnit = 1f;
    public static float Scale = 1f;
    public Vector2 NativeResolution = new Vector2(240,160);

    public void Awake()
    {
        var cam = GetComponent<Camera>();

        if (cam.orthographic)
        {
            Scale = Screen.height / NativeResolution.y;
            PixelsToUnit *= Scale;
            cam.orthographicSize = (Screen.height / 2.0f) / PixelsToUnit;
        } 
    }
}
