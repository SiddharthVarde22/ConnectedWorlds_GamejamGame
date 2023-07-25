using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    GameObject CreditsPanel;
    [SerializeField]
    GameObject MainPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButttonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void CreditsButtonPressed()
    {
        CreditsPanel.SetActive(true);
    }

    public void BackButtonPressedInMainMenu()
    {
        CreditsPanel.SetActive(false);
    }

    public void OnNextButtonPressed()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int maxScenes = SceneManager.sceneCountInBuildSettings;

        if(currentSceneIndex < (maxScenes - 1))
        {
            currentSceneIndex++;
        }
        else
        {
            currentSceneIndex = 0;
        }
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
