using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool paused = false;
    public GameObject PauseMenuCanvas;

    public static bool Paused { get => paused; set => paused = value; }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Pause()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resumed()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
