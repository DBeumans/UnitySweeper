using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    private bool isMine;

    public bool GetIsMine { get { return isMine; } }

    [SerializeField]
    private Sprite[] emptySprites;

    [SerializeField]
    private Sprite mineSprite;

    private Grid grid;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isMine = Random.value < 0;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        grid.GetElements[x, y] = this;
    }

    private void OnMouseUpAsButton()
    {

        if(isMine)
        {
            grid.uncoverMines();
            Debug.Log("You Lose");
            return;
        }

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        loadSprites(grid.GetFloodFill.adjacentObject(x, y));

        grid.GetFloodFill.FFuncover(x, y, grid.GetWidth , grid.GetHeight,  new bool[grid.GetWidth, grid.GetHeight]);

        if (grid.isFinished())
            print("you win");

        return;
    }

    public void loadSprites(int adjacentCount)
    {
        if(isMine)
            spriteRenderer.sprite = mineSprite;
        else
            spriteRenderer.sprite = emptySprites[adjacentCount];
    }

    public bool IsCovered()
    {
        return spriteRenderer.sprite.texture.name == "default";
    }


    
}
