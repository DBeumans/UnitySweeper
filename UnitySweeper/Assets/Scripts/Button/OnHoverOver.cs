using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverOver : MonoBehaviour {

    [SerializeField]
    private Color highlightColor;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        highlightColor.a = 255;
    }

    private void OnMouseOver()
    {
        spriteRenderer.color = highlightColor;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
}
