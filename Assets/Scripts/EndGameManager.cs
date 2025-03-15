using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class EndGameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI starDisplay;
    public TextMeshProUGUI timeDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int total = GameManager.Instance.GetTotalScore();
        scoreDisplay.text = "Total score: "+ total;
        starDisplay.text = "Star score: " + (total/50);
        timeDisplay.text = "Total time: " + PlayerPrefs.GetFloat("PlayerTime", 0f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
