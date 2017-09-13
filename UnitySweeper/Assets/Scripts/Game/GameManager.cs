using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Keep track of the game.

    /*
        store elements to check...
    */

    [SerializeField]
    private GameObject defaultElement;
    public GameObject GetDefaultElement { get { return defaultElement; } }

    private static int width = 10;
    private static int height = 13;

    public int GetWidth { get { return width; } set { if (value < 5) return; width = value; } }
    public int GetHeight { get { return height; } set { if (value < 5) return; height = value; } }

    private Element[,] elements = new Element[width, height];
    public Element[,] GetElements { get { return elements; } }

    private FloodFill floodFill;

    private void Start()
    {
        floodFill = GetComponent<FloodFill>();
    }


    /// <summary>
    /// Use this function to check the clicked element and apply Flood Fill algorithm.
    /// </summary>
    /// <param name="obj"></param>
    public void CheckElement(Element obj)
    {
        // Recieving the correct element.
        if (obj.GetIsMine) 
        {
            uncoverMines();
            return;
        }

        int x = (int)obj.transform.position.x;
        int y = (int)obj.transform.position.y;
        obj.loadSprites(floodFill.adjacentObject(x, y));

        floodFill.FFuncover(x, y, GetWidth, GetHeight, new bool[GetWidth, GetHeight]);

        if (isFinished())
        {

        }
            

        return;

    }

    /// <summary>
    /// Use this function to uncover all the mines.
    /// </summary>
    private void uncoverMines()
    {
        foreach (Element elem in elements)
            if (elem.GetIsMine)
                elem.loadSprites(0);
    }

    /// <summary>
    /// Use this function to check if the game is finished.
    /// </summary>
    /// <returns></returns>
    private bool isFinished()
    {
        // checks if there are still covered no-mines left.
        foreach (Element elem in elements)
            if (elem.IsCovered() && !elem.GetIsMine)
                return false;
        return true;
    }

    private void gameWon()
    {
        //switch state
        print("won");
    }

    private void gameFinished()
    {
        //switch state
        print("lose");
    }
}
