using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFill : MonoBehaviour {
    
    private int width;

    private int height;
    
    private GamePlay gamePlay;

    private void Start()
    {
        gamePlay = GetComponent<GamePlay>();
    }

    public void FFuncover(int x, int y, int w, int h, bool[,] visited )
    {
        width = w;
        height = h;
        // Coordinates in Range?
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            if (visited[x, y])
                return;

            // uncover the element
            gamePlay.GetElements[x, y].loadSprites(adjacentObject(x, y));

            // If its close to a mine stop.
            if (adjacentObject(x, y) > 0)
                return;

            visited[x, y] = true;

            FFuncover(x - 1, y, w, h, visited);
            FFuncover(x + 1, y, w, h, visited);
            FFuncover(x, y - 1, w, h, visited);
            FFuncover(x, y + 1, w, h, visited);
        }
    }

    public bool objectAt(int x, int y)
    {
        // check if the object with the given x and y is a mine, if not return false.
        if (x >= 0 && y >= 0 && x < width && y < height)
            return gamePlay.GetElements[x, y].GetIsMine;
        return false;
    }

    // Adjacent == neighbour
    public int adjacentObject(int x, int y)
    {
        int count = 0;

        if (objectAt(x, y + 1)) count++; // top
        if (objectAt(x + 1, y + 1)) count++; // top-right
        if (objectAt(x + 1, y)) count++; // right
        if (objectAt(x + 1, y - 1)) count++; // bottom-right
        if (objectAt(x, y - 1)) count++; // bottom
        if (objectAt(x - 1, y - 1)) count++; // bottom-left
        if (objectAt(x - 1, y)) count++; // left
        if (objectAt(x - 1, y + 1)) count++; // top-left

        return count;
    }
}
