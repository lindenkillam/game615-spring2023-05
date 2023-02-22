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
    public TextMeshProUGUI Timer;
    public int score;
    float moveSpeed = 5f;
    float rotateSpeed = 75f;
    void Start()
    {
        score = 1;
        TimerOn = true;
        TimeLeft = 50;
    }

    // Update is called once per frame
    void Update()
    {

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * moveSpeed * vAxis, Space.World);

        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

        if (TimerOn)
        {
            if (TimeLeft > 0 && score < 3)
            {
                TimeLeft -= Time.deltaTime;
                Timer.text = TimeLeft.ToString();
            }
            else if (TimeLeft > 0 && score == 3)
            {
                ScoreText.text = " Winner!";
            }
            else
            {
                TimeLeft = 0;
                Timer.text = TimeLeft.ToString();
                TimerOn = false;
                ScoreText.text = "You lose! ";

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score ++;
            Destroy(other.gameObject);
            
        }
    }
}
