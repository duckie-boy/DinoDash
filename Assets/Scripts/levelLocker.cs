using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelLocker : MonoBehaviour
{
    [SerializeField] Button[] levelButtons;
    public int levelAt;
    void Start()
    {
        PlayerPrefs.DeleteAll();
        levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for(int i = 1; i < levelButtons.Length; i++) {
            if(i + 1 > levelAt) {
                levelButtons[i].interactable = false;
            }
        }
    }
}
