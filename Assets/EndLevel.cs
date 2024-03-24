using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] GameObject EndLevelMenu;
    [SerializeField] private ScreenFader screenFader;
    public void loadMenu() {
        screenFader.FadeToColor("Main Menu");
    }
    public void restart() {
        screenFader.FadeToColor("LevelOne");
    }
    public void nextLevel() {
        //screenFader.FadeToColor("LevelTwo");
    }
}
