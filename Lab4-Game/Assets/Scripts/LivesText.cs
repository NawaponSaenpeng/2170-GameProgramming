using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    public void LivesUpdate(int lives)
    {
        livesText.text = $"Lives:{lives}";
    }
}
