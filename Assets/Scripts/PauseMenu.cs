using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPasued = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] private ScreenFader screenFader;
    [SerializeField] AudioSource music;

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
        music.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPasued = false;
    }
    public void Pause() {
        music.Pause();
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
        screenFader.FadeToColor(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        isPasued = false;
    }
}
