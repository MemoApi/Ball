using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{


   
    // sonsuz level için hazýrlýklar yapýlacak
    // sonsuz level kaldý
    // laser ateþleme sesi yapýlabilir   


    

    private int score;

    public GameObject PausePanel;
    public GameObject InGamePanel;
    public GameObject FinishGamePanel;
    public TextMeshProUGUI InGameScoreText;
    public TextMeshProUGUI FinishGameScoreText;

    private void OnEnable()
    {
        EventManager.CoinCollided += ScoreUp;
        EventManager.GameFinished += LevelFinished;
        EventManager.ObstacleCollided += ResetScore;

    }  
    private void Start()
    {
       
        
        Time.timeScale = 1;
        score = 0;
        InGameScoreText.text = score.ToString();

        InGamePanel.SetActive(true);
        PausePanel.SetActive(false);
        FinishGamePanel.SetActive(false);
       
    }

    

    

    private void ResetScore()
    {
        score = 0;
        InGameScoreText.text = score.ToString();
    }
    void ScoreUp()
    {
        score++;
        InGameScoreText.text = score.ToString();
        FinishGameScoreText.text = score.ToString();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        InGamePanel.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        InGamePanel.SetActive(true);
        PausePanel.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void ExitGame() => Application.Quit();
    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings >= SceneManager.GetActiveScene().buildIndex + 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            Debug.Log("oyun bitti");
        //DAHA SONRA DÖNÜLECEK
        
    }

    void LevelFinished()
    {
        FinishGamePanel.SetActive(true);
        InGamePanel.SetActive(false);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        EventManager.ObstacleCollided -= ResetScore;
        EventManager.CoinCollided -= ScoreUp;
        EventManager.GameFinished -= LevelFinished;
        

    }



}
