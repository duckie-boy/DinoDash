using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeKeeper : MonoBehaviour
{
    [SerializeField] float timeLeft = 100;
    [SerializeField] bool timeOn = true;
    [SerializeField] TMP_Text timerText;

    void update() {
        if(timeOn) {
            if(timeLeft > 0) {
                timeLeft -= Time.deltaTime;
                updateTime(timeLeft);
            }
            else {
                Debug.Log("DEATH");
            }
        }
    }

    void updateTime(float currentTime) {
        timerText.text = timeLeft.ToString();
    }
}
