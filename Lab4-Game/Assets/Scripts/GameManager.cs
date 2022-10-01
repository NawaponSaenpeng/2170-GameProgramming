using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LivesText _livesText;

    [SerializeField] private int lives = 3;
    
    // Simple singleton script. This is the easiest way to create and understand a singleton script.

    private void Start()
    {
        LivesUpdate();
    }

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (lives == 1)
        {
            SceneManager.LoadScene(0);
            lives += 3;
            _livesText.LivesUpdate(lives);
        }
        else
        {
            SceneManager.LoadScene(GetCurrentBuildIndex());
        }
        DOTween.KillAll();
    }

    public void LoadNextLevel()
    {
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        DOTween.KillAll();
    }

    private int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private void LivesUpdate()
    {
        _livesText.LivesUpdate(lives);
    }

    public void DecreaseLive()
    {
        lives -= 1;
        LivesUpdate();
    }
}
