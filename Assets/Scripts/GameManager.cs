using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static int score = 0;
    public int totalScore = 0;
    public static GameManager Instance;
    public TextMeshProUGUI scoreDisplay;
    public GameObject scorePanel;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void IncrementScore()
    {
        score++;
        totalScore += score;
    }

    public void RestartLevelScore()
    {
        totalScore = totalScore - score;
        score = 0;
    }

    public void EndOfLevelScore()
    {
        score = 0;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        scorePanel.SetActive(true);
        if(Instance)
        {
            scoreDisplay.text = "Score: " + score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + totalScore;
    }
}
