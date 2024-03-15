using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public GameObject scoreUI;
    private Text m_scoreText;
private int m_currentScore;

    void Start()
    {
        m_currentScore = 0;
        m_scoreText = scoreUI.GetComponent<Text>();
    }

    public void AddPoints(int points)
    {
        m_currentScore += points;
        m_scoreText.text = "";
        m_scoreText.text = m_currentScore.ToString();
    }
}
