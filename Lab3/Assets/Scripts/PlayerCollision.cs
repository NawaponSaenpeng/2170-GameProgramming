using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Collider2D _playerCollider;
    
    private GameManager _gameManager;
    private void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard"))) return;
        
        _gameManager.ProcessPlayerDeath();

    }
}
