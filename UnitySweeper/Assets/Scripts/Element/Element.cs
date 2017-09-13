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

    private SpriteRenderer spriteRenderer;


    private GamePlay gamePlay;

    private void Start()
    {
        gamePlay = FindObjectOfType<GamePlay>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        isMine = Random.value < gamePlay.GetMineChance;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        gamePlay.GetElements[x, y] = this;
    }

    private void OnMouseUpAsButton()
    {
        gamePlay.CheckElement(this);
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
