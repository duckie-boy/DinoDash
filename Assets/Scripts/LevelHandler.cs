using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;
    public void LevelOne() {
        //SceneManager.LoadScene("LevelOne");
        screenFader.FadeToColor("LevelOne");
    }
}
