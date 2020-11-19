﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    public TextMeshProUGUI text;
    public Text textOver, textWin;
    int score;



    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void ChangeScore(int coinValue){
        score += coinValue;
        text.text = "X" + score.ToString();
        textOver.text = "Puntaje : " + score.ToString();
        textWin.text = "Puntaje : " + score.ToString();
    }
}
