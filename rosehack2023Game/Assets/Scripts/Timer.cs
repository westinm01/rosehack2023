using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float duration = 60;

    private TMP_Text timerText;
    private bool timerActive = false;
    private float timeRemaining;
    [SerializeField]
    private ScoreSystem scores;
    [SerializeField]
    private GameObject redWinScreen;
    [SerializeField]
    private GameObject blueWinScreen;
    [SerializeField]
    private GameObject tieScreen;

    private void Awake()
    {
        timeRemaining = duration;
        timerText = GetComponent<TMP_Text>();

        // remove later 
        timerActive = true;
    }

    void Update()
    {
        if (timerActive)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            timerActive = false;

            if(scores.getLeftScore() > scores.getRightScore())
            {
                redWinScreen.SetActive(true);
            }
            else if(scores.getLeftScore() < scores.getRightScore()){
                blueWinScreen.SetActive(true);
            }
            else
            {
                tieScreen.SetActive(true);
            }
            Time.timeScale = 0;
        }
        timerText.text = Mathf.RoundToInt(timeRemaining).ToString();
    }
}
