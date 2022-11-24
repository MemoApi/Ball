using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    // laser pool olu�turuldu
    // laser atma i�lemi yap�ld�
    // laser Triggerdaki sorun ��z�ld�


    // ilk �� level haz�rlanacak
    // sonsuz level i�in haz�rl�klar yap�lacak
    // ana ekran tasarlanacak
    // lazer ate�leme sesi eklenecek
    // alt�n toplama ve �lme efektleri eklenecek


    

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
    public void ExitGame() => Application.Quit();
    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings >= SceneManager.GetActiveScene().buildIndex + 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            Debug.Log("oyun bitti");
        //DAHA SONRA D�N�LECEK
        
    }

    void LevelFinished()
    {
        FinishGamePanel.SetActive(true);
        InGamePanel.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.ObstacleCollided -= ResetScore;
        EventManager.CoinCollided -= ScoreUp;
        EventManager.GameFinished -= LevelFinished;
        

    }



}
