using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    const bool LEFT_PLAYER = true;
    const bool RIGHT_PLAYER = false;

    [SerializeField]
    TMP_Text leftPlayerScoreText;
    [SerializeField]
    TMP_Text rightPlayerScoreText;

    private int leftScore = 0;
    private int rightScore = 0;

    public void AddScore(bool team, int amount)
    {
        if (team == LEFT_PLAYER)
        {
            leftScore += amount;
            UpdateText(leftPlayerScoreText, leftScore);
        }
        else
        {
            rightScore += amount;
            UpdateText(rightPlayerScoreText, rightScore);
        }
    }

    private void UpdateText(TMP_Text textField, int score)
    {
        textField.text = score.ToString();
    }

    public int getLeftScore()
    {
        return leftScore;
    }

    public int getRightScore()
    {
        return rightScore;
    }
}
