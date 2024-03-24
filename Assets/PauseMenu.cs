using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPasued = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] private ScreenFader screenFader;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPasued) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPasued = false;
    }
    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPasued = true;
    }
    public void loadMenu() {
        screenFader.FadeToColor("Main Menu");
        Time.timeScale = 1f;
        isPasued = false;
    }
    public void restart() {
        screenFader.FadeToColor("LevelOne");
        Time.timeScale = 1f;
        isPasued = false;
    }
}
