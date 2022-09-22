using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        FindGameMananger();
    }

    private void FindGameMananger()
    {
        if (_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        FindGameMananger();
        _gameManager.TriggerNextScene();
        
    }
}
