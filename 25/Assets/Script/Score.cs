using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public int ScoreValue;
  
    public void AddScore()
    {
        ScoreValue++;
        scoreText.text = ScoreValue.ToString();
    }
    
}
