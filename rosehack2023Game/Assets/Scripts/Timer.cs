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

            // TODO: end game
        }
        timerText.text = Mathf.RoundToInt(timeRemaining).ToString();
    }
}
