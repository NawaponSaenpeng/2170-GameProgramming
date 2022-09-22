using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemColorRandom : MonoBehaviour
{
    public GemColors color;
    [SerializeField] private Sprite[] spritesArray;
    [SerializeField] private int randomColor;
    [SerializeField] private SpriteRenderer render;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        randomColor = Random.Range(0, spritesArray.Length);
        switch (randomColor)
        {
            case 0:
                color = GemColors.Red;
                break;
            case 1:
                color = GemColors.Blue;    
                break;
            case 2:
                color = GemColors.Green;   
                break;
        }

        render.sprite = spritesArray[randomColor];

    }
}
