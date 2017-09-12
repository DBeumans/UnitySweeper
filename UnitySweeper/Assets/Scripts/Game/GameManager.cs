using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {



    // Keep track of the game.

    /*
        store elements to check lateron.......
    */

    private static int width = 10;
    private static int height = 13;

    public int GetWidth { get { return width; } set { if (value < 5) return; width = value; } }
    public int GetHeight { get { return height; } set { if (value < 5) return; height = value; } }

    private Element[,] elements = new Element[width, height];
    public Element[,] GetElements { get { return elements; } }

    public delegate void GameEventManager();

    public GameEventManager gameEventManager;

    private void Start()
    {
        gameEventManager += gameWon;
        gameEventManager += gameFinished;
    }

    private void gameWon()
    {

    }

    private void gameFinished()
    {

    }
}
