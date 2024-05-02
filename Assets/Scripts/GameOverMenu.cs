using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] ScreenFader screenFader;

    public void Restart() {
        screenFader.FadeToColor("LevelOne");
        Time.timeScale = 1f;
    }

    public void loadMenu() {
        screenFader.FadeToColor("Main Menu");
        Time.timeScale = 1f;
    }
}
