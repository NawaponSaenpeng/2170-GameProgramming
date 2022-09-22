using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private SoCollectible collectibleObject;

    private void Start()
    {
        Debug.Log(collectibleObject.GetCollectible());
    }
}
