using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Class name needs to match file name, jeez
public class TimerScript : MonoBehaviour
{
    private Text timerText;
    private float levelTime;

    //added void return type    
    void Start()
    {
        timerText = GetComponent<Text>();
        ResetTimer();
    }

    public void ResetTimer()
    {
        levelTime = 30;
    }

    // Update is called once per frame
    //fixedUpdate is not called once a frame, so this is technically a lie
    void FixedUpdate()
    {
        if (levelTime > 0)
        {
            //you invented a time machine, congrats
            levelTime -= Time.deltaTime;
            //this is ugly and horrible code but it does what I want
            //timerText.text = (float)((int)(levelTime*10))/10 + " SECONDS LEFT";
            timerText.text = levelTime.ToString("F1") + " SECONDS LEFT";
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    //ahh! Missing a bracket!
}

