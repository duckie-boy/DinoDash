using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;
    public void LevelOne() {
        screenFader.FadeToColor("LevelOne");
    }
    public void LevelTwo() {
        screenFader.FadeToColor("LevelTwo");
    }
    public void LevelThree() {
        screenFader.FadeToColor("LevelThree");
    }
    public void LevelFour() {
        screenFader.FadeToColor("LevelFour");
    }
}
