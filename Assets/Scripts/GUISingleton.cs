using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUISingleton : MonoBehaviour
{
    public GameObject normalGUI;
    public GameObject pauseGUI;
    
    [HideInInspector] public GUISingleton instance;

    bool isPaused;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        normalGUI.SetActive(true);
        pauseGUI.SetActive(false);

        DontDestroyOnLoad(this);
    }


    public void PauseGame(bool isPausing)
    {
        isPaused = isPausing;

        if (isPausing)
        {
            normalGUI.SetActive(false);
            pauseGUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            normalGUI.SetActive(true);
            pauseGUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        normalGUI.SetActive(true);
        pauseGUI.SetActive(false);
        SceneManager.LoadScene("InputFolder");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("InputFolder"))
            PauseGame(!isPaused);
        }
    }
}
