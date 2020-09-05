using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Did you seriously just comment this out
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    private Text scoreText;
    private int score;

    public static ScoreScript S;
    
    void Start() {
        //changed 0.0f to 0, score is an int
        score = 0;
        scoreText = GetComponent<Text>();
        DisplayScore();
        S = this;
    }

    //Function isn't ever referenced in this script, therefore would be useless if private
    public void IncreaseScore() {
        score++;
        DisplayScore();
    }
    
    public void DecreaseScore() {
        //changed - operator to --, decrement
        score--;
        DisplayScore();
    }

    private void DisplayScore() {
        //scr -> score
        scoreText.text = "SCORE: " + score;
    }
}
