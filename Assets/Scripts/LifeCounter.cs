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
    [SerializeField] AudioSource gameOverSound;
    [SerializeField] AudioSource addLifeSound;
    [SerializeField] AudioSource loseLifeSound;
    [SerializeField] AudioSource music;

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
        else {
            loseLifeSound.Play();
        }
    }

    public void AddLife() {
        addLifeSound.Play();
        if(livesRemaining < 3) {
            lives[livesRemaining].enabled = true;
            livesRemaining++;
        }
    }

    public void ResetLife() {
        livesRemaining = 3;
        lives[0].enabled = true;
        lives[1].enabled = true;
        lives[2].enabled = true;
    }

    public int getLives() {
        return this.livesRemaining;
    }

    public void setLives(int newLives) {
        this.livesRemaining = newLives;
    }

    public void gameOver() {
        music.Pause();
        Time.timeScale = 0f;
        gameOverSound.Play();
        gameOverMenu.SetActive(true);
    }
}
