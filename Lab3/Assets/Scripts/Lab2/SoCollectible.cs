using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Colloectibles")]
public class SoCollectible : ScriptableObject
{
    [SerializeField] private string collectibleName;
    [SerializeField] private GemColors gemColors;

    public string GetCollectible()
    {
        return collectibleName;
    }
}
