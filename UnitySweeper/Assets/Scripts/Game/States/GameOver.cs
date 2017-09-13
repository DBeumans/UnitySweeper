using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : GameStates
{

    public override void Enter()
    {
        Debug.Log("lose");
    }

    public override void Act()
    {

    }

    public override void Reason()
    {

    }

    private void uncoverMines()
    {

    }

    private bool isFinished()
    {
        return true;
    }
}
