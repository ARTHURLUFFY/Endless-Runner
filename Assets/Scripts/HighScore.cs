using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScore;


    public void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void Update()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        //highScore.text = FindObjectOfType<Character>().highScore.ToString();
    }

}
