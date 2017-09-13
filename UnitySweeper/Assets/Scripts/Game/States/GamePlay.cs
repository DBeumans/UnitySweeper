using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : GameStates
{
    [SerializeField]
    private GameObject defaultElement;

    private int width = 10;
    private int height = 13;
    
    private float mineChance;
    public float GetMineChance { get { return mineChance; } }

    private Element[,] elements;
    public Element[,] GetElements { get { return elements; } }

    private FloodFill floodFill;
    private GameManager gameManager;
    private GenerateGrid generateGrid;
    private GameStateMachine gameStateMachine;

    public override void Enter()
    {
        mineChance = 0.15f;
        elements = new Element[width, height];

        gameManager = GetComponent<GameManager>();
        generateGrid = GetComponent<GenerateGrid>();
        gameStateMachine = GetComponent<GameStateMachine>();
        floodFill = GetComponent<FloodFill>();

        // Generate Level
        generateGrid.Generate(gameManager.GetWidth, gameManager.GetHeight, gameManager.GetDefaultElement);

    }

    public void CheckElement(Element obj)
    {
        // Recieving the correct element.
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
