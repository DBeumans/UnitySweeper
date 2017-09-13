using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour {
    private int width;
    private int height;
    
    public int GetWidth { get { return width; } set { width = (int)checkValue(value); } }
    public int GetHeight { get { return height; } set { height = (int)checkValue(value); } }

    private float checkValue(float value)
    {
        if (value < 10 || value > 30)
            return 10;

        return value;
    }
}
