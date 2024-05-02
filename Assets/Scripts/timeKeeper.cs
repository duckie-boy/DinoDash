using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeKeeper : MonoBehaviour
{
    [SerializeField] float totalTime = 100f;
    [SerializeField] float timeLeft;
    [SerializeField] bool timeOn = true;
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject gameOverMenu;

    void Start() {
        timeLeft = totalTime;
        timerText.GetComponent<TextMeshProUGUI>().text = timeLeft.ToString("F0");
    }
    void Update() {
        if(timeOn) {
            if(timeLeft > 0) {
                updateTime(timeLeft);
                timeLeft -= Time.deltaTime;
            }
            else {
                gameOver();
            }
        }
    }
    void updateTime(float currentTime) {
        timerText.GetComponent<TextMeshProUGUI>().text = currentTime.ToString("F0");
    } 
    public void gameOver() {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }
}
