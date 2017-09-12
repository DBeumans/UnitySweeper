using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : GameStates
{

    /*
    Generate level
    */
    private GameManager gameManager;
    private GenerateGrid generateGrid;

    private FloodFill floodFill;
    public FloodFill GetFloodFill { get { return floodFill; } }

    public override void Enter()
    {
        gameManager = GetComponent<GameManager>();
        generateGrid = GetComponent<GenerateGrid>();
        
    }

    public override void Leave()
    {

    }

    public override void Act()
    {

    }

    public override void Reason()
    {

    }
}
