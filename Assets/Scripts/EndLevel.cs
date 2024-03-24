using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] GameObject EndLevelMenu;
    [SerializeField] private ScreenFader screenFader;
    public void loadMenu() {
        Time.timeScale = 1f;
        screenFader.FadeToColor("Main Menu");
    }
    public void restart() {
        Time.timeScale = 1f;
        screenFader.FadeToColor("LevelOne");
    }
    public void nextLevel() {
        Time.timeScale = 1f;
        //screenFader.FadeToColor("LevelTwo");
    }
}
