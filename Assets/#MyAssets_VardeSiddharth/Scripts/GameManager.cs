using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    GameObject winPanel;
    [SerializeField]
    GameObject gameOverPanel;


    bool world1EndReached;
    bool world2EndReached;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        world1EndReached = false;
        world2EndReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        ReachedTheEnd();
    }

    public void ResumeButtonPressed()
    {
        pausePanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    void ReachedTheEnd()
    {
        if(world1EndReached && world2EndReached)
        {
            winPanel.SetActive(true);
        }
    }

    public void world1Win()
    {
        world1EndReached = true;
    }

    public void world2Win()
    {
        world2EndReached = true;
    }
}
