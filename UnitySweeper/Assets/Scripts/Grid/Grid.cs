using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    
    [SerializeField]
    private GameObject defaultElement;

    private static int width = 10;
    private static int height = 13;

    public int GetWidth { get { return width; } set { if (value < 5 ) return;  width = value; } }
    public int GetHeight { get { return height; } set { if (value < 5 ) return; height = value; } }

    private Element[,] elements = new Element[width, height];
    public Element[,] GetElements { get { return elements; } }

    private GenerateGrid generateGrid;

    private FloodFill floodFill;
    public FloodFill GetFloodFill { get { return floodFill; } }

    private void Start()
    {
        generateGrid = GetComponent<GenerateGrid>();
        floodFill = GetComponent<FloodFill>();

        generateGrid.Generate(width, height, defaultElement);
    }

    /// <summary>
    /// Use this function to uncover all the mines.
    /// </summary>
    public void uncoverMines()
    {
        foreach (Element elem in elements)
            if (elem.GetIsMine)
                elem.loadSprites(0);
    }

    /// <summary>
    /// Use this function to check if the game is finished.
    /// </summary>
    /// <returns></returns>
    public bool isFinished()
    {
        // checks if there are still covered no-mines left.
        foreach (Element elem in elements)
            if (elem.IsCovered() && !elem.GetIsMine)
                return false;
        return true;
    }
    
}
