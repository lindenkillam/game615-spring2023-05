using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimerText;
    public int score;
    float moveSpeed = 5f;
    float rotateSpeed = 75f;
    void Start()
    {
        score = 1;
        TimerOn = true;
        TimeLeft = 30;
    }

    // Update is called once per frame
    void Update()
    {

        if (TimerOn)
        {
            if (TimeLeft > 0 && score < 6)
            {
                TimeLeft -= Time.deltaTime;
                TimerText.text = TimeLeft.ToString();
            }
            else if (TimeLeft > 0 && score == 6)
            {
                ScoreText.text = "You Win!";
            }
            else
            {
                TimeLeft = 0;
                TimerText.text = TimeLeft.ToString();
                TimerOn = false;
                ScoreText.text = "You lose! Don't know how to stop game yet, so just pretend gameover:D";

            }

        }
    }
}
