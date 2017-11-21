using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private static bool mouse_left;
    public static bool Mouse_Left { get { return mouse_left; } }

    private static bool mouse_right;
    public static bool Mouse_Right { get { return mouse_right; } }
    
    private KeyCode mouseleft;
    private KeyCode mouseright;
    private void Update()
    {
        mouseleft = KeyCode.Mouse0;
        mouseright = KeyCode.Mouse1;
        mouse_left = Input.GetKeyDown(mouseleft);
        mouse_right = Input.GetKeyDown(mouseright);
        
    }
}
