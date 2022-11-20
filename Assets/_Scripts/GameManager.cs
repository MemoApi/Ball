using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{    

    private int score;

    public GameObject PausePanel;
    public GameObject InGamePanel;
    public TextMeshProUGUI InGameScoreText;

    private void OnEnable()
    {
        EventManager.CoinCollided += ScoreUp;
        EventManager.ObstacleCollided += ResetScore;
        EventManager.GameFinished += NextLevel;
    }  
    private void Start()
    {
        Time.timeScale = 1;
        score = 0;
        InGameScoreText.text = score.ToString();

        InGamePanel.SetActive(true);
        PausePanel.SetActive(false);
       
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
        //DAHA SONRA DÖNÜLECEK
        
    }



    private void OnDisable()
    {
        EventManager.ObstacleCollided -= ResetScore;
        EventManager.CoinCollided -= ScoreUp;
        EventManager.GameFinished -= NextLevel;

    }



}
