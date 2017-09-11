using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    
    [SerializeField]
    private GameObject defaultElement;

    private static int width = 15;
    private static int height = 15;

    public int GetWidth { get { return width; } set { if (value < 5 || value > 25) return;  width = value; } }
    public int GetHeight { get { return height; } set { if (value < 5 || value > 25) return; height = value; } }

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

    public void uncoverMines()
    {
        foreach (Element elem in elements)
            if (elem.GetIsMine)
                elem.loadSprites(0);
    }

    public bool isFinished()
    {
        foreach (Element elem in elements)
            if (elem.IsCovered() && !elem.GetIsMine)
                return false;
        return true;
    }
    
}
