using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    public GemColors color;

    void Start()
    {
        if (TryGetComponent(out GemColorRandom gemColorRandom))
        {
            color = gemColorRandom.color;
        }
    }

    GemColors GetColor()
    {
        return this.color;
    }
    void SetColor(GemColors color)
    {
        this.color = color ;
    }
}
