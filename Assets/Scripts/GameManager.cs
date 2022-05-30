using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    private void Awake()
    {
        I = this;
    }

    public float score;
    public bool canPlay = false;
    public bool gameStarted = false;

    public CharacterMove characterMove;
    public UIManager ui;

    private Touch touch;

    void Update()
    {
        CalculateScore();
    }

    public void CalculateScore()
    {
        if (canPlay)
        {
            score += Time.deltaTime;
        }
    }
    public void Fail()
    {
        StopGame();
        ui.EnableRetryMenu(true);
    }

    public void StopGame()
    {
        canPlay = false;
        characterMove.StopCharacter();
    }

    public void StartGame()
    {
        ui.EnableMainMenu(false);
        gameStarted = true;
        canPlay = true;
        characterMove.StartMovement();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
