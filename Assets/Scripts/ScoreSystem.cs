using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class ScoreSystem : MonoBehaviour
{
    public GameObject scoreUI;
    private Text m_scoreText;
    private int m_currentScore;
    [SerializeField]private AudioSource audioSource3;

    void Start()
    {
        m_currentScore = 0;
        m_scoreText = scoreUI.GetComponent<Text>();
        // audioSource3 = this.GetComponent<AudioSource>();
        audioSource3 = GameObject.FindGameObjectWithTag("Score").GetComponent<AudioSource>();
    }

    public void AddPoints(int points)
    {
        m_currentScore += points;
        m_scoreText.text = "";
        m_scoreText.text = m_currentScore.ToString();
        audioSource3.Play();
    }

    public void ResetScore()
    {
        m_scoreText.text = "0";
        m_currentScore = 0;
    }
}
