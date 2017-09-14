using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : CameraStates
{

    private int width;
    private int height;

    private GameOptions gameOptions;

    private Camera cam;

    public override void Enter()
    {
        cam = GetComponent<Camera>();
        gameOptions = FindObjectOfType<GameOptions>();
        width = gameOptions.GetWidth;
        height = gameOptions.GetHeight;

        calculateMiddlePoint(width, height);
    }

    private void calculateMiddlePoint(int w, int h)
    {
        w = w / 2;
        h = h / 2;

        cam.transform.position = new Vector3(w, h, -w + -h);

    }

    public override void Act()
    {

    }

    public override void Reason()
    {

    }
}
