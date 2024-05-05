using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] GameObject EndLevelMenu;
    [SerializeField] private ScreenFader screenFader;
    [SerializeField] private string nextScene;
    public void loadMenu() {
        Time.timeScale = 1f;
        screenFader.FadeToColor("Main Menu");
    }
    public void restart() {
        Time.timeScale = 1f;
        screenFader.FadeToColor(SceneManager.GetActiveScene().name);
    }
    public void nextLevel() {
        Time.timeScale = 1f;
        screenFader.FadeToColor(nextScene);
    }
}
