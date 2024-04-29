using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] Image[] lives;
    [SerializeField] int livesRemaining;
    [SerializeField] GameObject gameOverMenu;

    void start() {
        livesRemaining = 3;
        lives[0].enabled = true;
        lives[1].enabled = true;
        lives[2].enabled = true;
    }

    public void LoseLife() {
        livesRemaining--;
        lives[livesRemaining].enabled = false;
        if(livesRemaining == 0) {
            gameOver();
        }
    }

    public int getLives() {
        return this.livesRemaining;
    }

    public void setLives(int newLives) {
        this.livesRemaining = newLives;
    }

    public void gameOver() {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
    }
}
