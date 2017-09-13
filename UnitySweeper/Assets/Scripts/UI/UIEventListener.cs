using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventListener : MonoBehaviour {

    public delegate void UI_Event(GameObject hideUI, GameObject showUI);
    public UI_Event UI_EventHandler;

    private void Start()
    {
        UI_EventHandler += showUI;
    }

    private void showUI(GameObject hideUI = null, GameObject showUI = null)
    {
        if(hideUI != null)
            hideUI.SetActive(false);

        showUI.SetActive(true);
    }

}
