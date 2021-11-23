using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreTextUI;

    public Text highScore;


    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore").ToString("0");
    }

    void LateUpdate()
    {
        scoreTextUI.text = player.position.z.ToString("0");
    }
}
