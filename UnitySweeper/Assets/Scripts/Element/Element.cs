using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {

    [SerializeField]
    private bool isMine;

    public bool GetIsMine { get { return isMine; } set { isMine = value; } }

    private bool isFlagged;
    public bool GetIsFlagged { get { return isFlagged; } }

    [SerializeField]
    private Sprite[] emptySprites;

    [SerializeField]
    private Sprite mineSprite;
    [SerializeField]
    private Sprite flagSprite;
    [SerializeField]
    private Sprite defaultSprite;

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
    private void OnMouseOver()
    {
        if (InputManager.Mouse_Left)
        {
            gamePlay.CheckElement(this);
        }
        if (InputManager.Mouse_Right)
        {
            setflagSprite();
            gamePlay.CheckElementsEvent();
        }
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

    public bool IsFlagged()
    {
        return spriteRenderer.sprite.texture.name == "flag";
    }

    private void setflagSprite()
    {
        if (this.IsFlagged())
        {
            this.spriteRenderer.sprite = defaultSprite;
            return;
        }
        if (!IsCovered())
            return;

        this.spriteRenderer.sprite = flagSprite;
        isFlagged = true;
    }

    
}
