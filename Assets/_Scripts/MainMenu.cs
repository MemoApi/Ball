using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject TutorialsPanel;
    public GameObject MainMenuPanel;



    private void Start()
    {
        BackToMainMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        // level 4 e gidecek ,, sonsuz level
    }

    public  void OpenTutorialsPanel()
    {

        MainMenuPanel.SetActive(false);
        TutorialsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MainMenuPanel.SetActive(true);
        TutorialsPanel.SetActive(false);

    }


    public void StartTutorial(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
