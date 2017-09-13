using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : GameStates
{
    [SerializeField]
    private GameObject defaultElement;

    private int width;
    private int height;
    
    private float mineChance;
    public float GetMineChance { get { return mineChance; } }

    private Element[,] elements;
    public Element[,] GetElements { get { return elements; } }

    private FloodFill floodFill;
    private GenerateGrid generateGrid;
    private GameStateMachine gameStateMachine;
    private GameOptions gameOptions;

    public override void Enter()
    {
        gameOptions = FindObjectOfType<GameOptions>();
        mineChance = 0.15f;

        width = gameOptions.GetWidth;
        height = gameOptions.GetHeight;

        elements = new Element[width, height];

        generateGrid = GetComponent<GenerateGrid>();
        gameStateMachine = GetComponent<GameStateMachine>();
        floodFill = GetComponent<FloodFill>();

        // Generate Level
        generateGrid.Generate(width,height, defaultElement, "Elements", "default");

    }

    public void CheckElement(Element obj)
    {
        if (obj.GetIsMine)
        {
            uncoverMines();
            gameStateMachine.setState(GameStateMachine.GameAvailableStates.finish);
            return;
        }

        int x = (int)obj.transform.position.x;
        int y = (int)obj.transform.position.y;
        obj.loadSprites(floodFill.adjacentObject(x, y));

        floodFill.FFuncover(x, y, width, height, new bool[width, height]);
    
        if (isFinished())
        {
            gameStateMachine.setState(GameStateMachine.GameAvailableStates.won);
        }
        return;

    }

    private void uncoverMines()
    {
        foreach (Element elem in elements)
            if (elem.GetIsMine)
                elem.loadSprites(0);
    }

    private bool isFinished()
    {
        // checks if there are still covered no-mines left.
        foreach (Element elem in elements)
            if (elem.IsCovered() && !elem.GetIsMine)
                return false;
        return true;
    }

    public override void Act()
    {

    }

    public override void Reason()
    {

    }
}
