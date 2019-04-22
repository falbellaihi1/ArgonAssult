using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scoreboard : MonoBehaviour
{
    int score = 0;
    Text scoreText;
   

    private void Start()
    {
        scoreText = GetComponent<Text>();
        
    }
  

    public void ScoreHit(int scorePerHit)
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();
    }
}
