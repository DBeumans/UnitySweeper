using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : GameStates
{

    private UIEventListener ui_EventListener;

    [SerializeField]
    private GameObject hideUI;
    [SerializeField]
    private GameObject showUI;

    public override void Enter()
    {
        ui_EventListener = GetComponent<UIEventListener>();
        ui_EventListener.UI_EventHandler(hideUI, showUI);
    }

    public override void Act()
    {
       
    }

    public override void Reason()
    {

    }
}
